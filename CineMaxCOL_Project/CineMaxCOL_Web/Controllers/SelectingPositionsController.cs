using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CineMaxCOL_BILL.Service;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;
using CineMaxCOL_Web.Models;
using CineMaxCOL_Web.Models.PuestosYReservas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace CineMaxCOL_Web.Controllers
{
    public class SelectingPositionsController : Controller
    {
        private readonly SelectingPositionsServices _selectingPositionsServices;
        private readonly MarketTemporalService _TdemporalPositionServices;
        private readonly CineMaxColContext _context;

        public SelectingPositionsController(SelectingPositionsServices authServices, MarketTemporalService TemporalPositionServices, CineMaxColContext context)
        {
            _selectingPositionsServices = authServices;
            _TdemporalPositionServices = TemporalPositionServices;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        //This actions it's about almacenate or saving every positions such as 1A and the others. 19/05/2025
        public async Task<IActionResult> ReservarTemporalmente(int idFuncion, int IdSillaPorFuncion)
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                int? idUsuario = null;
                if (int.TryParse(userId, out var parsedId))
                {
                    idUsuario = parsedId;
                }
                var destruc = new SillasPorFuncion
                {
                    IdFuncion = idFuncion,
                    Estado = "Temporal",
                    IdSilla = IdSillaPorFuncion,
                    ReservadoHasta = DateTime.Now.AddSeconds(10),
                    IdUsuario = idUsuario
                };

                await _context.SillasPorFuncions.AddAsync(destruc);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                TempData["error"] = $"Error por parte de CineMaxCOL {e.Message}";
                return StatusCode(500, $"Error al reservar el asiento temporalmente: {e.Message}");
            }
        }

        public async Task<IActionResult> UpdateEverythingSeats()
        {
            try
            {
                var ahora = DateTime.Now;
                var sillasVencidas = await _context.SillasPorFuncions
                    .Where(x => x.Estado == "Temporal" && x.ReservadoHasta < ahora)
                    .ToListAsync();

                _context.SillasPorFuncions.RemoveRange(sillasVencidas);
                await _context.SaveChangesAsync();

                TempData["success"] = "Puestos temporales actualizados correctamente.";
            }
            catch
            {
                TempData["error"] = "Hubo un error al actualizar los puestos.";
            }

            return NoContent();
        }

        public async Task<IActionResult> InformationMainMovie(string SalaId, string IdPelicula, string identificador)
        {
            var funcion = await _selectingPositionsServices
                .Service_SelectedFuncionMovieAndMoreThings(SalaId, IdPelicula, identificador)
                ?? new Funcion();

            // Obtener todas las sillas de la sala
            var sillas = await _context.Sillas
                .Where(s => s.IdSala == funcion.IdSala)
                .ToListAsync();

            // Obtener sillas ya reservadas para esta función
            var sillasFuncion = await _context.SillasPorFuncions
            .Include(x => x.IdUsuarioNavigation)
                .Where(sf => sf.IdFuncion == funcion.Id)
                .ToListAsync();

            // Mapear todas las sillas con su estado actual o libre
            var resultado = sillas.Select(silla =>
            {
                var sillaFuncion = sillasFuncion.FirstOrDefault(sf => sf.IdSilla == silla.Id);
                return new SillasPorFuncion
                {
                    Id = sillaFuncion?.Id ?? 0,
                    IdFuncion = funcion.Id,
                    IdSilla = silla.Id,
                    Estado = sillaFuncion?.Estado ?? "Libre",
                    ReservadoHasta = sillaFuncion?.ReservadoHasta,
                    IdUsuario = sillaFuncion?.IdUsuario,
                    IdSillaNavigation = silla
                };
            }).ToList();

            var destruct = new DTO_PuestosYReservar
            {
                sillasPorFuncions = resultado,
                funcionDto = funcion
            };

            return View("Index", destruct);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}