using AutoMapper;
using CineMaxCOL_BILL.Service;
using CineMaxCOL_Web.Models.Comida;
using Microsoft.AspNetCore.Mvc;

namespace CineMaxCOL_Web.Controllers
{
    [Route("[controller]")]
    public class ComidaController : Controller
    {
        private readonly CineComidaService _cineComidaService;
        private readonly IMapper _map;
        private readonly MunicipioService _municipioService;
        public ComidaController(CineComidaService cineComidaService, IMapper mapper, MunicipioService municipioService)
        {
            _cineComidaService = cineComidaService;
            _map=mapper;
            _municipioService=municipioService;
        }


        [HttpGet] // Para apenas entrar a la vista principal mostrar los municipios
        public async Task<IActionResult> Comidas()
        {
            var municipios = new ComidaViewModel
            {
                Municipios = await _municipioService.TraerMunicipios() 
            };
            return View(municipios);
        }

        [HttpPost] // Para traer elementos según el municipio, sin embargo, envía de nuevo los municipios completos para que el usuario pueda seleccionar otro
        public async Task<IActionResult> Comidas(int id)
        {
            var modelo = new ComidaViewModel
            {
                Municipios = await _municipioService.TraerMunicipios(),
                CineComidas = await _cineComidaService.TraerComida(id),
                Categorias = await _cineComidaService.TraerCategorias()
            };             
            return View(modelo);  
        }
    }
}
