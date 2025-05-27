
using CineMaxColEntity;

namespace CineMaxColDal.Interfaces
{
    public interface ICategorias : IGenericRepository<CategoriaComidum>
    {
        Task<CategoriaComidum> TraerCategoriaId(int id);
    }
}