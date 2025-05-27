using CineMaxCOL_Entity;

namespace CineMaxCOL_DAL.Repository.Interface
{
    public interface IMarketTemporalPosition_Repository<T> where T : class
    {
        Task<bool> AddTemporalRepository(AsientosTemporale asientosTemporale);
    }
}