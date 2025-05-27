using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CineMaxCOL_BILL.Service;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;
using CineMaxCOL_Web.Models.ToSummaryPay;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CineMaxCOL_Web.Controllers
{
    public class PaymentdGetAway : Controller
    {
        private readonly PaymentBuyTickets _authService;
        private readonly DetailsMovieService _auhtDetailsService;

        private readonly CineMaxColContext _context;

        public PaymentdGetAway(PaymentBuyTickets service, CineMaxColContext context, DetailsMovieService DetailsMovieService)
        {
            _authService = service;
            _context = context;
            _auhtDetailsService = DetailsMovieService;
        }

        public async Task<IActionResult> Index()
        {

            int idUsuario = 0;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var parsedId))
            {
                idUsuario = parsedId;
            }

            var BrinfInformationLogInUser = await _authService.BringInformationLogInUserServices(idUsuario);
            if (BrinfInformationLogInUser != null)
            {
                return View(BrinfInformationLogInUser);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistersPay(Tarjeta tarjeta)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Por favor completa todos los campos obligatorios correctamente.";
                return View("Index", tarjeta);
            }
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int? idUsuario = null;
            if (int.TryParse(userId, out var parsedId))
            {
                idUsuario = parsedId;
            }

            var response = new Tarjeta
            {
                IdUsuario = idUsuario,
                NombreTitular = tarjeta.NombreTitular,
                CorreoElectronico = tarjeta.CorreoElectronico,
                NumeroTarjeta = tarjeta.NumeroTarjeta,
                FechaExpiracion = tarjeta.FechaExpiracion,
                TipoTarjeta = tarjeta.TipoTarjeta
            };

            var responsePayRegister = await _authService.RegisterCardUsServices(response);
            if (!responsePayRegister)
            {
                TempData["error"] = "Tenemos problemas al registrar la tarjeta.";
                return View("Index");
            }
            
            var destruct = new SummaryToPay
            {
                tarjetaByUsuario = await _authService.BringInformationLogInUserServices(idUsuario ?? 0),
                funcion = await _auhtDetailsService.GetSpeacillyFuction(5)
            };

            return View("~/Views/SummaryBuy/Index.cshtml", destruct);
        }
        public async Task<IActionResult> RightPersonLogIn(int idUser)
        {


            var destruct = new SummaryToPay
            {
                tarjetaByUsuario = await _authService.BringInformationLogInUserServices(idUser),
            };

            return View("~/Views/SummaryBuy/Index.cshtml", destruct);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}

