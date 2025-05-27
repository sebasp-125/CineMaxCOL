using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CineMaxColWeb.Controllers
{
    [Route("[controller]")]
    public class ProfileUserController : Controller
    {
        private readonly ILogger<ProfileUserController> _logger;

        public ProfileUserController(ILogger<ProfileUserController> logger)
        {
            _logger = logger;
        }

        [Route("HistorialCompras")]
        public IActionResult HistorialCompras()
        {
            return View();
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