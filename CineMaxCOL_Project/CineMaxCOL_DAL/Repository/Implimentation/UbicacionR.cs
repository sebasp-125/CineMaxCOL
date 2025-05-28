using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class UbicacionR : IUbicacion
    {
        private readonly CineMaxColContext _dbcontext;

        public UbicacionR(CineMaxColContext cineMaxColContext)
        {
            _dbcontext = cineMaxColContext;
        }
        public async Task<Ubicacion> Actualizar(Ubicacion entidad)
        {
            var local = _dbcontext.Set<Ubicacion>()
            .Local
            .FirstOrDefault(e => e.Id == entidad.Id);

            if (local != null)
            {
                _dbcontext.Entry(local).State = EntityState.Detached;
            }

            _dbcontext.Set<Ubicacion>().Update(entidad);
            return entidad;
        }

       

        public async Task<Ubicacion> Agregar(Ubicacion entidad)
        {
            await _dbcontext.Set<Ubicacion>().AddAsync(entidad);
            return entidad;
        }

        public async Task<Ubicacion> Eliminar(Ubicacion entidad)
        {
            _dbcontext.Set<Ubicacion>().Remove(entidad);
            return entidad;
        }

        public async Task<IEnumerable<Ubicacion>> Traer()
        {
            return await _dbcontext.Set<Ubicacion>().ToListAsync();
        }

        public async Task<Ubicacion?> TraerUbicacionId(int id)
        {
            return await _dbcontext.Set<Ubicacion>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<IEnumerable<Ubicacion>> TraerVId(int id)
        {
            throw new NotImplementedException();
        }
    }
}