using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CineMaxCOL_Web.Controllers
{
    [Route("[controller]")]
    public class ProfileUserController : Controller
    {
        private readonly CineMaxColContext _context;

        public ProfileUserController(CineMaxColContext context)
        {
            _context = context;
        }

        [Route("HistorialCompras")]
        public IActionResult HistorialCompras()
        {
            return View();
        }

        [Route("GetAllHistorialCompras")]
        public async Task<IActionResult> GetAll_HistorialCompras()
        {
            try
            {
                var response = await _context.HistorialCompras
                .Include(x => x.IdReservaNavigation)
                    .ThenInclude(x => x.IdFuncionNavigation)
                    .ThenInclude(x => x.IdPeliculaNavigation)
                .Include(x => x.IdUsuarioNavigation)
                .ToListAsync();
                return View("HistorialCompras", response);
            }
            catch
            {
                return View("HistorialCompras", new List<HistorialCompra>());
            }
        }



        [Route("Promos")]
        public IActionResult Promos()
        {
            return View();
        }
        [Route("MediosPago")]
        public IActionResult MediosPago()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}