namespace CineMaxCOL_DAL.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
    }
}