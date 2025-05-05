using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class LandingRepository<T> : ILandingRepository<T> where T : class
    {
        private readonly CineMaxColContext _context;
        private readonly DbSet<T> _dbset;

        public LandingRepository(CineMaxColContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T> GetByIdMovie(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task<List<Pelicula>> GetMovieByMunicipality(int id)
        {
            try
            {
                var response = await _context.Peliculas
                .Include(p => p.IdCineNavigation)
                    .ThenInclude(c => c.IdUbicacionNavigation)
                .Where(p => p.IdCineNavigation.IdUbicacion == id)
                .ToListAsync();
                return response;
            }
            catch
            {
                return new List<Pelicula>();
            }
        }

        public Task<List<T>> GetMovieAndCineById(int id)
        {
            throw new NotImplementedException();
        }

    }
}