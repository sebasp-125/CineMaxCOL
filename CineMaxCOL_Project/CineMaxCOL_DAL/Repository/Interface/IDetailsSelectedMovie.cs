using CineMaxCOL_Entity;

namespace CineMaxCOL_DAL.Repository.Interface
{
    public interface IDetailsSelectedMovie<T>
    {
        Task<List<Funcion>> GetCinesWithMovies(string Identificador);
        Task<Funcion> GetSpeciallyFuncion(int id);
    }
}