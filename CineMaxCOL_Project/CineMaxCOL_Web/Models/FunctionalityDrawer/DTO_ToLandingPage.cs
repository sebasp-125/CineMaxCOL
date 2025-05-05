using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_Entity;

namespace CineMaxCOL_Web.Models.FunctionalityDrawer
{
    public class DTO_ToLandingPage
    {
        public List<PeliculaViewModel> DTO_ToLandingPage_AllMovies {get; set;}
        public List<PeliculaViewModel> DTO_ToLandingPage_MoviesByMunicipality {get; set;}
        public List<Municipio> DTO_ToLandingPage_AllMunicipality {get;set;}
    }
}