using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CineMaxCOL_Web.Controllers
{
    public class PaymentdGetAway : Controller
    {
        private readonly IUnitOfWork _logger;

        public PaymentdGetAway(IUnitOfWork  logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RegistersPay()
        {
            var response = await _logger._UnitSendEmail.ExtractInformationAboutEmail();
            if (!response) {
                Console.WriteLine("Error");
                return BadRequest();
            }
            return View("Index");
        }

        public IActionResult RecoletInformation_ProccessPayment(string idfuction, int numbersOftickets)
        {
            return View("Index");
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}