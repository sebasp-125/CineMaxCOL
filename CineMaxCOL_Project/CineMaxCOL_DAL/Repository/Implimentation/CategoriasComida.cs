using CineMaxCol_DAL.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class CategoriasComida : ICategorias
    {
        private readonly CineMaxColContext _dbcontext;
        public CategoriasComida(CineMaxColContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<CategoriaComidum> Actualizar(CategoriaComidum entidad)
        {
            var local = _dbcontext.Set<CategoriaComidum>()
            .Local
            .FirstOrDefault(e => e.Id == entidad.Id); // Esta funcion evita que se trabe el programa al usar la id de una entidad al mismo tiempo en dos funciones diferentes, error que tenía yo

            if (local != null)
            {
                _dbcontext.Entry(local).State = EntityState.Detached;
            }
            _dbcontext.Set<CategoriaComidum>().Update(entidad);
            return entidad;
        }

        public async Task<CategoriaComidum> Agregar(CategoriaComidum entidad)
        {
            await _dbcontext.Set<CategoriaComidum>().AddAsync(entidad);
            return entidad;
        }

        public async Task<CategoriaComidum> Eliminar(CategoriaComidum entidad)
        {
            _dbcontext.Set<CategoriaComidum>().Remove(entidad);
            return entidad;
        }

        public async Task<IEnumerable<CategoriaComidum>> Traer()
        {
            return await _dbcontext.Set<CategoriaComidum>().ToListAsync();
        }

        public async Task<CategoriaComidum?> TraerCategoriaId(int id)
        {
            return await _dbcontext.Set<CategoriaComidum>().FirstOrDefaultAsync(c => c.Id == id);
        }

        // FUNCIONES SIN USO
        public Task<IEnumerable<CategoriaComidum>> TraerVId(int id)
        {
            throw new NotImplementedException();
        }
    }
}