using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CineMaxCOL_Web.Controllers
{
    [Route("[controller]")]
    public class CineController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public CineController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var Municipio = await _UnitOfWork.Municipios.Traer();
            return View(Municipio);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}