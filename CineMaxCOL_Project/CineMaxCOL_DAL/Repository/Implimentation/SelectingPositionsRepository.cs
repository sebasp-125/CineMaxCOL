using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class SelectingPositionsRepository : ISelectingPositions<Funcion>
    {
        private readonly CineMaxColContext _context;
        public SelectingPositionsRepository(CineMaxColContext context)
        {
            _context = context;
        }
        public async Task<Funcion> SelectedFuncionAndMoreThings(string salaId, string idPelicula, string identificador)
        {
            try
            {
                var test_two = await _context.Funcions
                    .Include(d => d.IdSalaNavigation)
                    .Include(f => f.IdPeliculaNavigation)
                    .Include(f => f.IdSalaNavigation)
                        .Where(f =>
                            f.IdPeliculaNavigation.Identificador == identificador &&
                            f.IdSala == int.Parse(salaId) &&
                            f.IdPelicula == int.Parse(idPelicula))
                        .FirstOrDefaultAsync();
                return test_two;
            }
            catch
            {
                return new Funcion();
            }

        }
    }
}