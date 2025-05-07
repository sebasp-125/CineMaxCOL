using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CineMaxCOL_Web.Models;
using CineMaxCOL_BILL.Service;
using System.Threading.Tasks;
using AutoMapper;
using CineMaxCOL_Web.Models.FunctionalityDrawer;

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

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var BringMovies = await _ServiceMovie.BringMovies_Service();
        var GetMunicipalitys = await _ServiceMovie.GetMunicipalitiesAsync();
        
        var PeliculasModel_Mapper = _map.Map<List<PeliculaViewModel>>(BringMovies);
        var drawer = new DTO_ToLandingPage{
            DTO_ToLandingPage_AllMovies = PeliculasModel_Mapper,
            DTO_ToLandingPage_AllMunicipality = GetMunicipalitys
        };
        return View(drawer);
    }

    [HttpPost]
    public async Task<IActionResult> NewInformationByFilterMunicipality(int id){
        var BringMoviesByMunicipality = await _ServiceMovie.BringMovieByMunicipality(id);
        var GetMunicipalitys = await _ServiceMovie.GetMunicipalitiesAsync();
        var MoviesByMunicipality_Mapper = _map.Map<List<PeliculaViewModel>>(BringMoviesByMunicipality);
        var drawer = new DTO_ToLandingPage{
            DTO_ToLandingPage_AllMunicipality = GetMunicipalitys,
            DTO_ToLandingPage_AllMovies = MoviesByMunicipality_Mapper,
        };
        return View("Index" , drawer);
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
