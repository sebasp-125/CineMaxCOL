using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CineMaxCOL_BILL.Service;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CineMaxCOL_Web.Controllers
{
    public class PaymentdGetAway : Controller
    {
        private readonly PaymentBuyTickets _authService;
        private readonly IUnitOfWork _Unit;

        public PaymentdGetAway(PaymentBuyTickets service)
        {
            _authService = service;
        }

        public IActionResult Index()
        {
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

            // var BrinfInformationLogInUser = 

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

            return View("~/Views/SummaryBuy/Index.cshtml", response);
        }


        public IActionResult RecoletInformation_ProccessPayment(string idfuction, int numbersOftickets)
        {
            return Redirect("Index");
        }
        public async Task<IActionResult> RegisterInformationOurSystems()
        {
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}