using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxColDal.DBContext;
using CineMaxColDal.Interfaces;
using CineMaxColEntity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxColDal.Implementación
{
    public class Peliculas : IPeliculas
    {
        private readonly CineMaxColContext _dbcontext;

        public Peliculas(CineMaxColContext cineMaxColContext)
        {
            _dbcontext = cineMaxColContext;
        }

        public async Task<IEnumerable<Pelicula>> TraerVId(int id)
        {
            return await _dbcontext.Set<Pelicula>()
                .Where(p => p.IdCine == id)
                .ToListAsync();
        }


        // FUNCIONES SIN USO
        public Task<Pelicula> Actualizar(Pelicula entidad)
        {
            throw new NotImplementedException();
        }

        public Task<Pelicula> Agregar(Pelicula entidad)
        {
            throw new NotImplementedException();
        }

        public Task<Pelicula> Eliminar(Pelicula entidad)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pelicula>> Traer()
        {
            throw new NotImplementedException();
        }

        public Task<Pelicula> TraerId(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}