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
    public class DetailsSelectedMovie<T> : IDetailsSelectedMovie<T> where T : class
    {
        private readonly CineMaxColContext _context;

        public DetailsSelectedMovie(CineMaxColContext context)
        {
            _context = context;
        }
        public async Task<List<Funcion>> GetCinesWithMovies(string Identificador)
        {
            try
            {
                var test_two = await _context.Funcions
                .Include(f => f.IdPeliculaNavigation)
                .Include(f => f.IdSalaNavigation)
                    .ThenInclude(s => s.IdCineNavigation)
                .Where(f => f.IdPeliculaNavigation.Identificador == Identificador)
                        .ToListAsync();
                return test_two;
            }
            catch
            {
                return new List<Funcion>();
            }
        }
        public async Task<Funcion> GetSpeciallyFuncion(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id debe ser mayor a cero.", nameof(id));
            return await _context.Funcions.FindAsync(id);
        }
    }
}