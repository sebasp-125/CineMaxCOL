using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxColEntity;

namespace CineMaxColDal.Interfaces
{
    public interface IPromociones : IGenericRepository<PromocionComidum>
    {
        Task<PromocionComidum> TraerPromoId(int id);
    }
}