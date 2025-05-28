using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CineMaxCOL_BILL.Service;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;
using CineMaxCOL_Web.Models.ToSummaryPay;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CineMaxCOL_Web.Controllers
{
    public class PaymentGetAwayController : Controller
    {
        private readonly PaymentBuyTickets _authService;
        private readonly DetailsMovieService _detailsMovieService;
        private readonly CineMaxColContext _context;
        private readonly IUnitOfWork _unit;
        public PaymentGetAwayController(PaymentBuyTickets service, CineMaxColContext context, DetailsMovieService detailsMovieService, IUnitOfWork unit)
        {
            _authService = service;
            _context = context;
            _detailsMovieService = detailsMovieService;
            _unit = unit;
        }

        private int IdActuallyUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            return (userIdClaim != null && int.TryParse(userIdClaim.Value, out int id)) ? id : 0;
        }

        public async Task<IActionResult> Index(int idFuncion)
        {
            HttpContext.Session.SetInt32("FuncionId", idFuncion);
            try
            {
                int userId = IdActuallyUser();
                var userInfo = await _authService.BringInformationLogInUserServices_Card(userId);
                if (userInfo != null)
                {
                    return View(userInfo);
                }

                TempData["error"] = "No se pudo obtener información del usuario.";
                return View();
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Ocurrió un error al cargar los datos: {ex.Message}";
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegistersPay(Tarjetum tarjeta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["error"] = "Por favor completa todos los campos obligatorios correctamente.";
                    return View("Index", tarjeta);
                }

                var nuevaTarjeta = new Tarjetum
                {
                    IdUsuario = IdActuallyUser(),
                    NombreTitular = tarjeta.NombreTitular,
                    CorreoElectronico = tarjeta.CorreoElectronico,
                    NumeroTarjeta = tarjeta.NumeroTarjeta,
                    FechaExpiracion = tarjeta.FechaExpiracion,
                    TipoTarjeta = tarjeta.TipoTarjeta
                };

                await _context.Tarjeta.AddAsync(nuevaTarjeta);
                await _context.SaveChangesAsync();


                var resumen = new SummaryToPay
                {
                    UsuarioByTarjeta = tarjeta,
                    funcion = await _context.Funcions.FindAsync(1) ?? new Funcion()
                };

                Console.WriteLine(resumen.funcion.IdPeliculaNavigation.Titulo);

                TempData["success"] = "Tarjeta registrada exitosamente.";
                return View("~/Views/SummaryBuy/Index.cshtml", resumen);
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Error inesperado al procesar el pago: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }



        public async Task<IActionResult> RightPersonLogIn()
        {
            try
            {
                var r = await _context.Tarjeta
                    .Include(x => x.IdUsuarioNavigation)
                    .Where(t => t.IdUsuario == IdActuallyUser())
                    .FirstOrDefaultAsync() ?? new Tarjetum();


                var resumen = new SummaryToPay
                {
                    UsuarioByTarjeta = r,
                    funcion = await _context.Funcions.FindAsync(1) ?? new Funcion()
                };
                return View("~/Views/SummaryBuy/Index.cshtml", resumen);
            }
            catch (Exception ex)
            {
                TempData["error"] = $"No fue posible obtener los datos del usuario: {ex.Message}";
                return RedirectToAction("Privacy", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}