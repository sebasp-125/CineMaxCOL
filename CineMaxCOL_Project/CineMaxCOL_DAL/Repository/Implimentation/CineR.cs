using CineMaxCol_DAL.Interface;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class CineR : ICineR
    {
        private readonly CineMaxColContext _dbcontext;

        public CineR(CineMaxColContext cineMaxColContext)
        {
            _dbcontext = cineMaxColContext;
        }

        public async Task<Cine> Actualizar(Cine entidad)
        {
            var local = _dbcontext.Set<Cine>()
            .Local
            .FirstOrDefault(e => e.Id == entidad.Id);

            if (local != null)
            {
                _dbcontext.Entry(local).State = EntityState.Detached;
            }

            _dbcontext.Set<Cine>().Update(entidad);
            return entidad;
        }

        public async Task<Cine> Agregar(Cine entidad)
        {
            await _dbcontext.Set<Cine>().AddAsync(entidad);
            return entidad;
        }

        public async Task<Cine> Eliminar(Cine entidad)
        {
            _dbcontext.Set<Cine>().Remove(entidad);
            return entidad;
        }

        public async Task<IEnumerable<Cine>> Traer()
        {
            return await _dbcontext.Set<Cine>().ToListAsync();
        }

        public async Task<Cine?> TraerCineId(int id)
        {
            return await _dbcontext.Set<Cine>().FirstOrDefaultAsync(c => c.Id == id);
        }


        // FUNCIONES SIN USO
        public Task<IEnumerable<Cine>> TraerVId(int id)
        {
            throw new NotImplementedException();
        }
    }
}