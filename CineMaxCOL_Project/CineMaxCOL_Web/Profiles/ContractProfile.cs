using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CineMaxCOL_Entity;
using CineMaxCOL_Web.Models;

namespace CineMaxCOL_Web.Profiles
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<Pelicula, PeliculaViewModel>();
            CreateMap<PeliculaViewModel, Pelicula>();
            CreateMap<Pelicula , DTO_SpeacillyMovieCines>();
            CreateMap<DTO_SpeacillyMovieCines , Pelicula>();
        }
    }
}