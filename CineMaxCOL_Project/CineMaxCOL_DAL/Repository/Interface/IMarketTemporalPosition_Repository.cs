using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_Entity;

namespace CineMaxCOL_DAL.Repository.Interface
{
    public interface IMarketTemporalPosition_Repository<T> where T : class
    {
        Task<bool> AddTemporalRepository(AsientosTemporale asientosTemporale);
    }
}