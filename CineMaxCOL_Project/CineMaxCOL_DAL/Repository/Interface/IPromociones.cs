using CineMaxCOL_Entity;

namespace CineMaxCol_DAL.Interface
{
    public interface IPromociones : IGenericRepository<PromocionComidum>
    {
        Task<PromocionComidum> TraerPromoId(int id);
    }
}