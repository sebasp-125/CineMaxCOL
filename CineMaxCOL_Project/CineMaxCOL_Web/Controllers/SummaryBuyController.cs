using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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

        private int IdActuallyUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            return (userIdClaim != null && int.TryParse(userIdClaim.Value, out int id)) ? id : 0;
        }

        [HttpPost]
        public async Task<IActionResult> GeneratePayReserva(int funcionid, decimal monto)
        {
            try
            {
                var destruc_Reserva = new Reserva
                {
                    IdCliente = IdActuallyUser(),
                    IdFuncion = funcionid,
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
                    Monto = monto,
                    IdTipoPago = 1,
                    FechaPago = DateTime.Now
                };

                var PagoGuarda = await _authService.RegisterPagoServices(destruc_Pago);
                if (!PagoGuarda)
                {
                    TempData["error"] = "Tenemos problemas con su pago.";
                    return View("Index");
                }
                return RedirectToAction("Index", "ProccesPay");
            }
            catch
            {
                TempData["error"] = "Tenemos problemas con su pago.";
                return View("Index");
            }

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}