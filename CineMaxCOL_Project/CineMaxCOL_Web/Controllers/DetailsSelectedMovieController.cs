using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CineMaxCOL_BILL.Service;
using CineMaxCOL_Web.Models;
using CineMaxCOL_Web.Models.FunctionalityDrawer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CineMaxCOL_Web.Controllers
{
    public class DetailsSelectedMovieController : Controller
    {
        private readonly IMapper _map;
        private readonly MovieService _authService;
        private readonly DetailsMovieService _authService_DetailsMovieService;


        public DetailsSelectedMovieController(MovieService authService , IMapper mapper , DetailsMovieService authService_DetailsMovieService)
        {
            _authService = authService;
            _authService_DetailsMovieService = authService_DetailsMovieService;
            _map = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int SelectId , string Identificate)
        {
            var responseFromService = await _authService.BrindSelectedMovie(SelectId);
            var BringCinesAboutMovie = await _authService_DetailsMovieService.GetCinesAboutMoviesAsync(Identificate);

            var AsignInformation = new DTO_ToSpeacllyCinesAboutMovies{
                To_SpeciallyMovie = responseFromService,
                DtoSpeciallyMovieCines = BringCinesAboutMovie
                
            };
            return View(AsignInformation);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}