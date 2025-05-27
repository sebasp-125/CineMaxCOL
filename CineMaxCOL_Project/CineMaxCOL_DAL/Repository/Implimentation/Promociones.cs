using CineMaxCol_DAL.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
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