using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CineMaxCOL_BILL.Service
{
    public class MovieService
    {
        private readonly IUnitOfWork _Unit;
        private readonly CineMaxColContext _context;
        public MovieService(IUnitOfWork Unit , CineMaxColContext context)
        {
            _Unit = Unit;
            _context = context;
        }

        public async Task<List<Pelicula>> BringMovies_Service(){
            return await _Unit.GetLandingRepository<Pelicula>().GetAll();
        }

        public async Task<Pelicula> BrindSelectedMovie(int id){
            var pelicula = await _Unit.GetLandingRepository<Pelicula>().GetByIdMovie(id);
            if(pelicula == null)
                return null;
            return pelicula;        
        }

        public async Task<List<Pelicula>> BringMovieByMunicipality(int id){
            return await _Unit.GetLandingRepository<Pelicula>().GetMovieByMunicipality(id);
        }

        public async Task<List<Municipio>> GetMunicipalitiesAsync()
        {
            return await _Unit.GetLandingRepository<Municipio>().GetAll();
        }

    }
}