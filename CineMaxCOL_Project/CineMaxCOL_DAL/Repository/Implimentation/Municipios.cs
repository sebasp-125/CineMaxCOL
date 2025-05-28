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
                .Include(m=>m.Ubicacions)
                 .ThenInclude(c=>c.Cines)
                .ToListAsync();
        }


        // FUNCIONES SIN USO
        public Task<Municipio> Actualizar(Municipio entidad)
        {
            throw new NotImplementedException();
        }

        public Task<Municipio> Agregar(Municipio entidad)
        {
            throw new NotImplementedException();
        }

        public Task<Municipio> Eliminar(Municipio entidad)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Municipio>> TraerVId(int id)
        {
            throw new NotImplementedException();
        }
    }
}