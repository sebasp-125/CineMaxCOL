using CineMaxCOL_Entity;

namespace CineMaxCOL_DAL.Repository.Interface
{
    public interface ILandingRepository<T> 
    {
        Task<List<Pelicula>> GetMovieByMunicipality(int id);
        Task<T> GetByIdMovie(int id);
        Task<List<T>> GetAll();
        Task<List<T>> GetMovieAndCineById(int id);
    }
}