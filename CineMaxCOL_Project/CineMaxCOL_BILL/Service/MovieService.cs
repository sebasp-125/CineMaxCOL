using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;

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

        public async Task<List<Pelicula>> BringMovies(){
            return await _Unit.PeliculaRepository.GetAll();
        }
    }
}