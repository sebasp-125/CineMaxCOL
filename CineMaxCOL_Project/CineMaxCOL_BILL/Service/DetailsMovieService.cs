using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;

namespace CineMaxCOL_BILL.Service
{
    public class DetailsMovieService
    {
        private readonly IUnitOfWork _Unit;
        private readonly CineMaxColContext _context;
        public DetailsMovieService(IUnitOfWork Unit, CineMaxColContext context)
        {
            _Unit = Unit;
            _context = context;
        }
        public async Task<List<Funcion>> GetCinesAboutMoviesAsync(string Indentificate)
        {
            return await _Unit.GetDetailsMoviesAndCine<Funcion>().GetCinesWithMovies(Indentificate);
        }

        
        public async Task<Funcion> GetSpeacillyFuction(int ?id)
        {
            return await _Unit.GetDetailsMoviesAndCine<Funcion>().GetSpeciallyFuncion(id ?? 0);
        }
    }
}