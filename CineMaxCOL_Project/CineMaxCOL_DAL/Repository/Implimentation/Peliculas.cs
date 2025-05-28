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
        public async Task<Pelicula> Actualizar(Pelicula entidad)
        {
           var local = _dbcontext.Set<Pelicula>()
            .Local
            .FirstOrDefault(e => e.Id == entidad.Id);

            if (local != null)
            {
                _dbcontext.Entry(local).State = EntityState.Detached;
            }

            _dbcontext.Set<Pelicula>().Update(entidad);
            return entidad;
        }

        public async Task<Pelicula> Agregar(Pelicula entidad)
        {
            await _dbcontext.Set<Pelicula>().AddAsync(entidad);
            return entidad;
        }

        public async Task<Pelicula> Eliminar(Pelicula entidad)
        {
            _dbcontext.Set<Pelicula>().Remove(entidad);
            return entidad;
        }

        public async Task<IEnumerable<Pelicula>> Traer()
        {
            return await _dbcontext.Set<Pelicula>().ToListAsync();
        }

        public async Task<Pelicula?> TraerPeliculaId(int id)
        {
             return await _dbcontext.Set<Pelicula>().FirstOrDefaultAsync(c => c.Id == id);
        }

        
    }
}