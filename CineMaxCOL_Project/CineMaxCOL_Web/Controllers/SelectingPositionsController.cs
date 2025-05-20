using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CineMaxCOL_BILL.Service;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;
using CineMaxCOL_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace CineMaxCOL_Web.Controllers
{
    public class SelectingPositionsController : Controller
    {
        private readonly SelectingPositionsServices _selectingPositionsServices;

        public SelectingPositionsController(SelectingPositionsServices authServices)
        {
            _selectingPositionsServices = authServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        //This actions it's about almacenate or saving every positions such as 1A and the others. 19/05/2025
        public async Task<IActionResult> TemporalMarketPosition(int position)
        {

            return Ok();
        }

        public async Task<IActionResult> InformationMainMovie(string SalaId, string IdPelicula, string identificador)
        {
            var response = await _selectingPositionsServices.Service_SelectedFuncionMovieAndMoreThings(SalaId, IdPelicula, identificador);
            if (response == null)
            {
                TempData["error"] = "error";
            }
            return View("Index", response);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
        {
            return View("Error!");
        }
    }
}