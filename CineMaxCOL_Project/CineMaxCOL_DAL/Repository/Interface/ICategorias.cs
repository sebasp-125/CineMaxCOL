using CineMaxCOL_Entity;

namespace CineMaxCol_DAL.Interface
{
    public interface ICategorias : IGenericRepository<CategoriaComidum>
    {
        Task<CategoriaComidum> TraerCategoriaId(int id);
    }
}