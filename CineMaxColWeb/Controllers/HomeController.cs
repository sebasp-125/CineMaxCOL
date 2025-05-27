using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CineMaxColWeb.Models;
using CineMaxColBLL.Services;
using AutoMapper;
using CineMaxColDal.Implementación;

namespace CineMaxColWeb.Controllers;

public class HomeController : Controller
{
    private readonly PeliculasService _peliculasService;
    private readonly IMapper _map;
    public HomeController(PeliculasService peliculasservice, IMapper mapper)
    {
        _peliculasService = peliculasservice;
        _map = mapper;
    }
    public async Task<IActionResult> Index()
    {
        var peliculas = await _peliculasService.TraerPeliculas(2);
        var PeliculasModel = _map.Map<IEnumerable<PeliculaViewModel>>(peliculas);
        return View(PeliculasModel);
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
