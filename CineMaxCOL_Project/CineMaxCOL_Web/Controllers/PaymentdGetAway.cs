using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CineMaxCOL_BILL.Service;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;
using CineMaxCOL_Web.Models.ToSummaryPay;
using Microsoft.AspNetCore.Mvc;

namespace CineMaxCOL_Web.Controllers
{
    public class PaymentGetawayController : Controller
    {
        private readonly PaymentBuyTickets _authService;
        private readonly DetailsMovieService _detailsMovieService;
        private readonly CineMaxColContext _context;
        private readonly IUnitOfWork _unit;

        public PaymentGetawayController(PaymentBuyTickets service, CineMaxColContext context, DetailsMovieService detailsMovieService, IUnitOfWork unit)
        {
            _authService = service;
            _context = context;
            _detailsMovieService = detailsMovieService;
            _unit = unit;
        }

        private int IdActuallyUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            return (userIdClaim != null && int.TryParse(userIdClaim.Value, out int id)) ? id : 0;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                int userId = IdActuallyUser();
                if (userId == 0)
                {
                    TempData["error"] = "Debe iniciar sesión para acceder a esta página.";
                    return RedirectToAction("Login", "Account");
                }

                var userInfo = await _authService.BringInformationLogInUserServices_Card(userId);
                if (userInfo != null)
                {
                    return View(userInfo);
                }

                TempData["error"] = "No se pudo obtener información del usuario.";
                return View(new SummaryToPay());
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Ocurrió un error al cargar los datos: {ex.Message}";
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegistersPay(Tarjetum tarjeta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["error"] = "Por favor completa todos los campos obligatorios correctamente.";
                    return View("Index", new SummaryToPay());
                }

                var nuevaTarjeta = new Tarjetum
                {
                    IdUsuario = null,
                    NombreTitular = tarjeta.NombreTitular,
                    CorreoElectronico = tarjeta.CorreoElectronico,
                    NumeroTarjeta = tarjeta.NumeroTarjeta,
                    FechaExpiracion = tarjeta.FechaExpiracion,
                    TipoTarjeta = tarjeta.TipoTarjeta
                };

                var tarjetaRegistrada = await _unit._UnitPaymentBuyTicktes<Tarjetum>().BringInformationLaterRegisterOurServices(nuevaTarjeta);

                if (tarjetaRegistrada == null)
                {
                    TempData["error"] = "Ocurrió un error al registrar la tarjeta. Intente nuevamente.";
                    return View("Index", new SummaryToPay());
                }

                var resumen = new SummaryToPay
                {
                    UsuarioByTarjeta = await _unit._UnitPaymentBuyTicktes<Tarjetum>().BringInformationLogInUser(IdActuallyUser())
                };

                TempData["success"] = "Tarjeta registrada exitosamente.";
                return View("~/Views/SummaryBuy/Index.cshtml", resumen);
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Error inesperado al procesar el pago: {ex.Message}";
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> RightPersonLogIn()
        {
            try
            {
                var resumen = new SummaryToPay
                {
                    UsuarioByTarjeta = await _authService.BringInformationLogInUserServices_Card(IdActuallyUser())
                };

                return View("~/Views/SummaryBuy/Index.cshtml", resumen);
            }
            catch (Exception ex)
            {
                TempData["error"] = $"No fue posible obtener los datos del usuario: {ex.Message}";
                return RedirectToAction("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
