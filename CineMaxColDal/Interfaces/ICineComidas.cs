using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxColEntity;

namespace CineMaxColDal.Interfaces
{
    public interface ICineComidas : IGenericRepository<CineComidum>
    {
        Task<CineComidum> TraerPlatoId(int id);
    }
}