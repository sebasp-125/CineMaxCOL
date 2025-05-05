using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CineMaxCOL_BILL.Service;
using CineMaxCOL_Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CineMaxCOL_Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogIn(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProccesRegister(Usuario usuario)
        {
            bool result = await _authService.RegisterUser(usuario);
            if (!result){
                TempData["error"] = "Tenemos problemas con tu Registro!";
                return RedirectToAction("Login", "Account");
            }
            
            TempData["success"] = "Bienvenido a CineMaxCOL";
            return View("LogIn");
        }

        [HttpPost]
        public async Task<IActionResult> ProccesLogIn(string email, string password)
        {
            Console.WriteLine(email + password);
            var (isValid, claims) = await _authService.ValidateUser(email, password);
            
            if (isValid)
            {
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                TempData["success"] = "Bienvenido a CineMaxCOL!";
                return RedirectToAction("Index", "Home");
            }
            TempData["error"] = "Credenciales Incorrectas!";
            return View("LogIn");
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["success"] = "Adios..";
            return RedirectToAction("LogIn");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}