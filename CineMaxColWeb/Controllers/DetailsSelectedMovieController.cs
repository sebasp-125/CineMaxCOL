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
    public class DetailsSelectedMovieController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }
}