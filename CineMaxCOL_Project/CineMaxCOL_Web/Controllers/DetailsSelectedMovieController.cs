using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_BILL.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CineMaxCOL_Web.Controllers
{
    public class DetailsSelectedMovieController : Controller
    {
        private readonly MovieService _authService;

        public DetailsSelectedMovieController(MovieService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int SelectId)
        {
            var responseFromService = await _authService.BrindSelectedMovie(SelectId);
            return View(responseFromService);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}