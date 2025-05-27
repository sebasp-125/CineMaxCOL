using CineMaxCOL_Entity;

namespace CineMaxCOL_DAL.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<Usuario>> GetAll();
        Task<bool> Add(Usuario t);

    }
}