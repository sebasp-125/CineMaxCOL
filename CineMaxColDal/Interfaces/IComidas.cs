using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxColEntity;

namespace CineMaxColDal.Interfaces
{
    public interface IComidas : IGenericRepository<Comidum>
    {
        Task<Comidum> TraerComidaGeneralId(int id);
    }
}