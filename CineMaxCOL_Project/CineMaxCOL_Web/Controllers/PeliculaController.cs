using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_BILL.Service;
using CineMaxCOL_Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CineMaxCOL_Web.Controllers
{
    [Route("[controller]")]
    public class PeliculaController : Controller
    {
        private readonly ILogger<PeliculaController> _logger;
        private readonly PeliculasService _peliculaService;

        public PeliculaController(ILogger<PeliculaController> logger, PeliculasService peliculasService)
        {
            _logger = logger;
            _peliculaService = peliculasService;
        }

        [HttpPost("Agregar_Pelicula_Cine")]
        public async Task<IActionResult> Agregar_Pelicula_Cine(Pelicula entidad)
        {
            if (entidad.Id == 0)
            {
                await _peliculaService.AgregarPelicula(entidad);
            }

            return RedirectToAction("Cines_Inicial","Cine");
        }

        [Route("EliminarPeliculaCine")]
        public async Task<IActionResult> EliminarPeliculaCine(int id, string? tipo)
        {

            var peliculaEncontrada = await _peliculaService.TraerPeliculaExistente(id);
            await _peliculaService.EliminarPelicula(peliculaEncontrada);

            return RedirectToAction("Cines_Inicial", "Cine");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}