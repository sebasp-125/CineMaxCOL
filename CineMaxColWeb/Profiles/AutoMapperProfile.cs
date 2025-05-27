using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CineMaxColEntity;
using CineMaxColWeb.Models;
using Microsoft.Data.SqlClient;

namespace CineMaxColWeb.Profiles
{
    public class AutoMapperProfile : Profile
    {
        //SE REDUJO EXHAUSTIVAMENTE EL AUTOMAPPER, SIN EMBARGO NI LO USO YA

        public AutoMapperProfile()
        {

            CreateMap<Pelicula, PeliculaViewModel>();
            CreateMap<PeliculaViewModel, Pelicula>();
        }
    }
}