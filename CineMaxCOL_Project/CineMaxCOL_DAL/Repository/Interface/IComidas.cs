using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_Entity;

namespace CineMaxCol_DAL.Interface
{
    public interface IComidas : IGenericRepository<Comidum>
    {
        Task<Comidum> TraerComidaGeneralId(int id);
    }
}