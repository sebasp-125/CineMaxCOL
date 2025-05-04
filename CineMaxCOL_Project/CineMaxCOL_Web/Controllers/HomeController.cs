using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CineMaxCOL_Web.Models;
using CineMaxCOL_BILL.Service;
using System.Threading.Tasks;
using AutoMapper;

namespace CineMaxCOL_Web.Controllers;

public class HomeController : Controller
{
    private readonly MovieService _ServiceMovie;
    private readonly IMapper _map;
    public HomeController(MovieService ServiceMovie, IMapper mapper)
    {
        _ServiceMovie = ServiceMovie;
        _map = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var peliculas = await _ServiceMovie.BringMovies();
        var PeliculasModel = _map.Map<IEnumerable<PeliculaViewModel>>(peliculas);
        return View(PeliculasModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    //Food
    public IActionResult Comidas()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
