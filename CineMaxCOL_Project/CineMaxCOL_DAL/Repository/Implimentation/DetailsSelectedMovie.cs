using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;


namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class DetailsSelectedMovie<T>  : IDetailsSelectedMovie<T> where T : class
    {
        private readonly CineMaxColContext _context;
        private readonly DbSet<T> _dbSet;
        
        public DetailsSelectedMovie(CineMaxColContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }
        public async Task<List<Pelicula>> GetCinesWithMovies(string Identificador)
        {
            try
            {
                var feelding = await _context.Peliculas
                    .Include(x => x.IdCineNavigation)
                        .ThenInclude(x => x.IdUbicacionNavigation)
                        .Where(x => x.Identificador == Identificador)
                        .ToListAsync();           
                        return feelding;
            }
            catch
            {
                return new List<Pelicula>();
            }
        }
    }
}