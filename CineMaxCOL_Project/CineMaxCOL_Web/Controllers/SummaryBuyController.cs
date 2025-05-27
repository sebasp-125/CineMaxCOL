using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_BILL.Service;
using CineMaxCOL_Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CineMaxCOL_Web.Controllers
{
    public class SummaryBuyController : Controller
    {
        private readonly PaymentBuyTickets _authService;

        public SummaryBuyController(PaymentBuyTickets PaymentBuyTickets)
        {
            _authService = PaymentBuyTickets;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProccesPay()
        {
            return RedirectToAction("Index", "ProccesPay");
        }

        public async Task<IActionResult> GeneratePayReserva()
        {
            var destruc_Reserva = new Reserva
            {
                IdCliente = 28,
                IdFuncion = 5,
                FechaReserva = DateTime.Now,
                CantidadBoletos = 2,
                Estado = "Ocupado"
            };

            var reservaGuardada = await _authService.RegisterReservaServices(destruc_Reserva);
            if (reservaGuardada == null || reservaGuardada?.Id == null)
            {
                TempData["error"] = "Error al guardar la reserva.";
                return View("Index");
            }

            var destruc_Pago = new Pago
            {
                IdReserva = reservaGuardada.Id,
                Monto = 344444,
                IdTipoPago = 4,
                FechaPago = DateTime.Now
            };

            var PagoGuarda = await _authService.RegisterPagoServices(destruc_Pago);
            if (!PagoGuarda)
            {
                TempData["error"] = "Tenemos problemas con su pago.";
                return View("Index");
            }
                return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}