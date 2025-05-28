using CineMaxCOL_Entity;

namespace CineMaxCol_DAL.Interface
{
    public interface IPeliculas : IGenericRepository<Pelicula>
    {
        Task<Pelicula> TraerPeliculaId(int id);
    }
}