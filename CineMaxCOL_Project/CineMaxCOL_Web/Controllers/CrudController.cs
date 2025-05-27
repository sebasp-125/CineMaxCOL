using CineMaxCOL_BILL.Service;
using Microsoft.AspNetCore.Mvc;
using CineMaxCOL_Web.Models.Comida;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace CineMaxCOL_Web.Controllers
{
    [Route("[controller]")]
    public class CrudController : Controller
    {
        private readonly MunicipioService _MunicipioService;
        private readonly CineComidaService _cineComidaService;
        private readonly CloudinaryService _cloudinaryService;

        public CrudController(MunicipioService MunicipioService, CineComidaService cineComidaService, CloudinaryService cloudinaryService)
        {
            _MunicipioService = MunicipioService;
            _cineComidaService = cineComidaService;
            _cloudinaryService = cloudinaryService;
        }

        [Route("Index_Comidas")] // Para traer a la vista principal los municipios completos y ponemos CineComidas null para que no nos genere error por entrar la primera vez a la vista inicial 
        public async Task<IActionResult> Index_Comidas()
        {
            var Modelo = new ComidaViewModel
            {
                Municipios = await _MunicipioService.TraerMunicipios(),
                CineComidas = null,
            };
            return View(Modelo);
        }

        [HttpPost("Index_Comidas")] // Si un cine es seleccionado, mandamos su id para traer sus comidas relacionadas, por si ingresarmos una comida nueva a ese cine necesitamos las comidas generales para saber cuáles hay disponibles, y si queremos cambiar las categorias traemos la lista general
        // Igualmente si el usuario necesita seleccionar otro municipio mandamos la lista nuevamente 
        public async Task<IActionResult> Index_Comidas(int id)
        {
            var Modelo = new ComidaViewModel
            {
                Municipios = await _MunicipioService.TraerMunicipios(),
                CineComidas = await _cineComidaService.TraerComida(id),
                Comidas = await _cineComidaService.TraerComidaGeneral(),
                Categorias = await _cineComidaService.TraerCategorias(),
                TipoEntidad = "CineComida"
            };
            ViewBag.IdCine = id; // Importante para saber a qué cine va la comida ingresada o actualizada
            return View(Modelo);
        }

        [HttpPost("Index_Comidas_Generales")] // Si no se selecciona ningún cine, sino que se acciona el crud categorias o el crud comidas generales, se le asigna ese tipo a TipoEntidad, ¿Para? Pues para que todos los cruds puedan realizarse usando los mismos controladores: Agregar/Actualizar y Eliminar
        public async Task<IActionResult> Index_Comidas_Generales(string tipo)
        {
            var Modelo = new ComidaViewModel
            {
                Municipios = await _MunicipioService.TraerMunicipios(),
                Comidas = await _cineComidaService.TraerComidaGeneral(),
                Categorias = await _cineComidaService.TraerCategorias(),
                TipoEntidad = tipo
            };
            return View("Index_Comidas", Modelo);
        }

        [HttpPost("Agregar")] // Controlador Agregar (Dependiendo de la Id puede detectar si es un modelo existente, si así es, actualiza la entidad). 

        // FUNCIONA PARA EL CRUD DE CATEGORIA, CRUD COMIDAS GENERALES, CRUD COMIDAS DEL CINE, Y CRUD DE LAS PROMOCIONES 
        public async Task<IActionResult> Agregar(ComidaViewModel entidad, IFormFile? imagen, string? tipo, string? CategoriaNombre)
        {
            var resultado = "";
            if (imagen?.Length > 0)
            {
                using var stream = imagen.OpenReadStream(); //La lógica para subir la foto está en un servicio
                resultado = await _cloudinaryService.SubirFoto(imagen.FileName, stream, tipo, CategoriaNombre);
            }
            else
            {
                if (entidad.ComidaGeneral_s.Id != 0)
                {
                    var comida = await _cineComidaService.TraerPlatoGeneralId(entidad.ComidaGeneral_s.Id);
                    resultado = comida?.ImagenUrl ?? "";
                }
                else if (entidad.Categoria_s.Id != 0)
                {
                    var categoria = await _cineComidaService.TraerCategoriaId(entidad.Categoria_s.Id);
                    resultado = categoria?.ImagenUrl ?? "";
                }

                if (!string.IsNullOrEmpty(resultado))
                {
                    using var httpClient = new HttpClient();
                    using var imageStream = await httpClient.GetStreamAsync(resultado);
                    resultado = await _cloudinaryService.SubirFoto(Path.GetFileName(resultado), imageStream, tipo, CategoriaNombre);
                }
            }

            switch (entidad.TipoEntidad)
            {
                case "CineComida":
                    if (entidad.CineComida_s.Id == 0)
                    {
                        await _cineComidaService.AgregarComida(entidad.CineComida_s);
                    }
                    else
                    {
                        await _cineComidaService.ActualizarComida(entidad.CineComida_s);
                    }
                    break;

                case "Categorias":
                    entidad.Categoria_s.ImagenUrl = resultado;
                    if (entidad.Categoria_s.Id == 0)
                    {
                        await _cineComidaService.AgregarCategoriaComida(entidad.Categoria_s);
                    }
                    else
                    {
                        await _cineComidaService.ActualizarCategoria(entidad.Categoria_s);
                    }

                    break;

                case "Comidas":
                    entidad.ComidaGeneral_s.ImagenUrl = resultado;
                    if (entidad.ComidaGeneral_s.Id == 0)
                    {
                        await _cineComidaService.AgregarComidaGeneral(entidad.ComidaGeneral_s);
                    }
                    else
                    {
                        await _cineComidaService.ActualizarComidaGeneral(entidad.ComidaGeneral_s);
                    }
                    break;

                case "Promo":
                    if (entidad.Promos_s.Id == 0)
                    {
                        await _cineComidaService.AgregarPromo(entidad.Promos_s);
                    }
                    else
                    {
                        await _cineComidaService.ActualizarPromo(entidad.Promos_s);
                    }
                    break;
            }

            return RedirectToAction("Index_Comidas", "Crud");
        }

        [Route("Eliminar")] // Controlador eliminar.

        //FUNCIONA PARA EL CRUD DE CATEGORIA, CRUD COMIDAS GENERALES, CRUD COMIDAS DEL CINE, Y CRUD DE LAS PROMOCIONES
        public async Task<IActionResult> Eliminar(int id, string tipo)
        {
            switch (tipo)
            {
                case "CineComida":
                    var encontrado = await _cineComidaService.TraerPlatoId(id);
                    await _cineComidaService.EliminarComida(encontrado);
                    break;
                case "Categorias":
                    var encontradoCategoria = await _cineComidaService.TraerCategoriaId(id);
                    await _cineComidaService.EliminarComidaCategoria(encontradoCategoria);
                    break;
                case "Comida":
                    var encontradoGeneral = await _cineComidaService.TraerPlatoGeneralId(id);
                    await _cineComidaService.EliminarComidaGeneral(encontradoGeneral);
                    break;
                case "Promo":
                    var encontradoPromo = await _cineComidaService.TraerPromo(id);
                    await _cineComidaService.EliminarPromo(encontradoPromo);
                    break;

            }
            return RedirectToAction("Index_Comidas", "Crud");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}