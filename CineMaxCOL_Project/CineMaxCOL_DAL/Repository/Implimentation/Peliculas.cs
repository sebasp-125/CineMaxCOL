using CineMaxCol_DAL.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
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