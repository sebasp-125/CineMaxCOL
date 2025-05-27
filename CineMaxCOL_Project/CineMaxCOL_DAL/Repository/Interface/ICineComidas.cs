using CineMaxCOL_Entity;

namespace CineMaxCol_DAL.Interface
{
    public interface ICineComidas : IGenericRepository<CineComidum>
    {
        Task<CineComidum> TraerPlatoId(int id);
    }
}