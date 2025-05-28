using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CineMaxCOL_BILL.Service;
using CineMaxCOL_Entity;
using CineMaxCOL_Web.Models.Cine;

namespace CineMaxCOL_Web.Controllers
{
    [Route("[controller]")]
    public class CineController : Controller
    {
        private readonly MunicipioService _MunicipioService;
        private readonly PeliculasService _PeliculaService;

        public CineController(MunicipioService MunicipioService, PeliculasService PeliculaService)
        {
            _MunicipioService = MunicipioService;
            _PeliculaService = PeliculaService;
        }

        [Route("Cines_Inicial")]
        public async Task<IActionResult> Cines_Inicial()
        {
            try
            {
                var Municipio = new CineCompletoViewModel
                {
                    Municipios_Lista = await _MunicipioService.TraerMunicipios(),
                    Peliculas_Lista = await _PeliculaService.TraerTodasPelis()
                };
                ViewBag.Vista = null;
                return View("Cines_Inicial", Municipio);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpPost("Cines_Inicial")]
        public async Task<IActionResult> Cines_Inicial(string? vista)
        {
            var Municipio = new CineCompletoViewModel
            {
                Municipios_Lista = await _MunicipioService.TraerMunicipios(),
                Peliculas_Lista = await _PeliculaService.TraerTodasPelis()
            };
            ViewBag.Vista = vista;
            return View("Cines_Inicial", Municipio);
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar(CineCompletoViewModel entidad, string? tipo)
        {
            switch (tipo)
            {
                case "Cines":
                    if (entidad.Cine_s.Id == 0)
                    {
                        await _MunicipioService.AgregarCine(entidad.Cine_s);
                    }
                    else
                    {
                        await _MunicipioService.ActualizarCine(entidad.Cine_s);
                    }
                    break;
                case "Localidad":
                    if (entidad?.Ubicacion_s?.Id == 0)
                    {
                        await _MunicipioService.AgregarLocalidad(entidad.Ubicacion_s);
                    }
                    else
                    {
                        await _MunicipioService.ActualizarLocalidad(entidad.Ubicacion_s);
                    }
                    break;
                case "Municipio":
                    if (entidad?.Municipio_s?.Id == 0)
                    {
                        await _MunicipioService.AgregarMunicipio(entidad.Municipio_s);
                    }
                    else
                    {
                        await _MunicipioService.ActualizarMunicipio(entidad.Municipio_s);
                    }
                    break;
            }
            return RedirectToAction("Cines_Inicial");
        }

        [Route("Eliminar")] // Controlador eliminar.

        //FUNCIONA PARA EL CRUD DE CATEGORIA, CRUD COMIDAS GENERALES, CRUD COMIDAS DEL CINE, Y CRUD DE LAS PROMOCIONES
        public async Task<IActionResult> Eliminar(int id, string tipo)
        {
            switch (tipo)
            {
                case "Cines":
                    var cineEncontrado = await _MunicipioService.TraerCineExistente(id);
                    await _MunicipioService.EliminarCineExistente(cineEncontrado);
                    break;
                case "Localidad":
                    var localidadEncontrada = await _MunicipioService.TraerLocalidadExistente(id);
                    await _MunicipioService.EliminarLocalidadExistente(localidadEncontrada);
                    break;
                case "Municipio":
                    var municipioEncotrado = await _MunicipioService.TraerMunicipioExistente(id);
                    await _MunicipioService.EliminarMunicipio(municipioEncotrado);
                    break;
            }

            return RedirectToAction("Cines_Inicial");
        }

    }
}