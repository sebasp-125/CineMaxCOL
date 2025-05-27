using CineMaxCol_DAL.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class Comidas : IComidas
    {
        private readonly CineMaxColContext _dbcontext;

        public Comidas(CineMaxColContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Comidum> Actualizar(Comidum entidad)
        {
            var local = _dbcontext.Set<Comidum>()
            .Local
            .FirstOrDefault(e => e.Id == entidad.Id);

            if (local != null)
            {
                _dbcontext.Entry(local).State = EntityState.Detached;
            }

            _dbcontext.Set<Comidum>().Update(entidad);
            return entidad;
        }

        public async Task<Comidum> Agregar(Comidum entidad)
        {
            await _dbcontext.Set<Comidum>().AddAsync(entidad);
            return entidad;
        }

        public async Task<Comidum> Eliminar(Comidum entidad)
        {
            _dbcontext.Set<Comidum>().Remove(entidad);
            return entidad;
        }

        public async Task<IEnumerable<Comidum>> Traer()
        {
            return await _dbcontext.Set<Comidum>().ToListAsync();
        }


        public async Task<Comidum?> TraerComidaGeneralId(int id)
        {
            return await _dbcontext.Set<Comidum>().FirstOrDefaultAsync(c => c.Id == id);
        }
        

        // FUNCIONES SIN USO
        public Task<IEnumerable<Comidum>> TraerVId(int id)
        {
            throw new NotImplementedException();
        }
    }
}