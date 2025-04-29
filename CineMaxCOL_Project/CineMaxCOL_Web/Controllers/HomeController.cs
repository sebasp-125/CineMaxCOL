using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CineMaxCOL_Web.Models;
using CineMaxCOL_BILL.Service;
using System.Threading.Tasks;

namespace CineMaxCOL_Web.Controllers;

public class HomeController : Controller
{
    private readonly DiferentsServices _Services;

    public HomeController(DiferentsServices Services)
    {
        _Services = Services;
    }

    public IActionResult Index()
    {
        return View();
    }

    

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
