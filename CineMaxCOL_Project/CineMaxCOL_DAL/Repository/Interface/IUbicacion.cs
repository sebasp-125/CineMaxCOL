using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCol_DAL.Interface;
using CineMaxCOL_Entity;

namespace CineMaxCOL_DAL.Repository.Interface
{
    public interface IUbicacion : IGenericRepository<Ubicacion>
    {
        Task<Ubicacion> TraerUbicacionId(int id);
    }
}