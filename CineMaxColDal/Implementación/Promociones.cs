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
    public class Promociones : IPromociones
    {
        private readonly CineMaxColContext _dbcontext;

        public Promociones(CineMaxColContext cineMaxColContext)
        {
            _dbcontext = cineMaxColContext;
        }
        public async Task<PromocionComidum> Actualizar(PromocionComidum entidad)
        {
            _dbcontext.Set<PromocionComidum>().Update(entidad);
            return entidad;
        }

        public async Task<PromocionComidum> Agregar(PromocionComidum entidad)
        {
            await _dbcontext.Set<PromocionComidum>().AddAsync(entidad);
            return entidad;throw new NotImplementedException();
        }

        public async Task<PromocionComidum> Eliminar(PromocionComidum entidad)
        {
            _dbcontext.Set<PromocionComidum>().Remove(entidad);
            return entidad;
        }

        public async Task<PromocionComidum?> TraerPromoId(int id)
        {
            return await _dbcontext.Set<PromocionComidum>().FirstOrDefaultAsync(c => c.Id == id);
        }


        // FUNCIONES SIN USO
        public Task<IEnumerable<PromocionComidum>> Traer()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PromocionComidum>> TraerVId(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}