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
            CreateMap<Cine, DTO_Cine>();
            CreateMap<Ubicacion, DTO_Ubicacion>();

            CreateMap<Pelicula, DtoSpeciallyMovieCines>()
                .ForMember(dest => dest.Cine, opt => opt.MapFrom(src => src.IdCineNavigation));

        }
    }
    }
    