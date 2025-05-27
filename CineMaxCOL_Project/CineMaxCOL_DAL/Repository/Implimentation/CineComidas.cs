using CineMaxCol_DAL.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class CineComidas : ICineComidas
    {
        private readonly CineMaxColContext _dbcontext;

        public CineComidas(CineMaxColContext cineMaxColContext)
        {
            _dbcontext = cineMaxColContext;
        }

        public async Task<CineComidum> Actualizar(CineComidum entidad)
        {
            _dbcontext.Set<CineComidum>().Update(entidad);
            return entidad;
        }

        public async Task<CineComidum> Agregar(CineComidum entidad)
        {
            await _dbcontext.Set<CineComidum>().AddAsync(entidad);
            return entidad;
        }

        public async Task<CineComidum> Eliminar(CineComidum entidad)
        {
            _dbcontext.Set<CineComidum>().Remove(entidad);
            return entidad;
        }

        public async Task<IEnumerable<CineComidum>> TraerVId(int id)
        {
            return await _dbcontext.Set<CineComidum>()
                .Where(c => c.IdCineNavigation.Id == id)
                .Include(c => c.PromocionComida)
                .Include(c => c.IdComidaNavigation)
                .ThenInclude(c => c.Categoria)
                .ToListAsync();
        }
        public async Task<CineComidum?> TraerPlatoId(int id)
        {
            return await _dbcontext.Set<CineComidum>().FirstOrDefaultAsync(c => c.Id == id);
        }


        // FUNCIONES SIN USO
        public Task<IEnumerable<CineComidum>> Traer()
        {
            throw new NotImplementedException();
        }
    }
}