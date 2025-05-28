using CineMaxCol_DAL.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class Municipios : IMunicipios
    {
        private readonly CineMaxColContext _dbcontext;

        public Municipios(CineMaxColContext cineMaxColContext)
        {
            _dbcontext = cineMaxColContext;
        }

        public async Task<IEnumerable<Municipio>> Traer()
        {
            return await _dbcontext.Set<Municipio>()
                .Include(m => m.Ubicacions)
                    .ThenInclude(u => u.Cines)
                        .ThenInclude(c => c.CineComida)
                .Include(m => m.Ubicacions)
                    .ThenInclude(u => u.Cines)
                        .ThenInclude(c => c.Peliculas)
                .ToListAsync();
        }

        public async Task<Municipio> Actualizar(Municipio entidad)
        {
            var local = _dbcontext.Set<Municipio>()
            .Local
            .FirstOrDefault(e => e.Id == entidad.Id);

            if (local != null)
            {
                _dbcontext.Entry(local).State = EntityState.Detached;
            }

            _dbcontext.Set<Municipio>().Update(entidad);
            return entidad;
        }

        public async Task<Municipio> Agregar(Municipio entidad)
        {
            await _dbcontext.Set<Municipio>().AddAsync(entidad);
            return entidad;
        }

        public async Task<Municipio> Eliminar(Municipio entidad)
        {
            _dbcontext.Set<Municipio>().Remove(entidad);
            return entidad;
        }
        public async Task<IEnumerable<Municipio>> TraerVId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Municipio?> TraerMunicipioId(int id)
        {
            return await _dbcontext.Set<Municipio>().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}