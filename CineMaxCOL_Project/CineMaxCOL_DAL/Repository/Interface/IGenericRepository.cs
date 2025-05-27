namespace CineMaxCol_DAL.Interface
{
    public interface IGenericRepository<TEntidad> where TEntidad : class
    {
        Task<TEntidad> Agregar(TEntidad entidad);
        Task<IEnumerable<TEntidad>> Traer();
        Task<IEnumerable<TEntidad>> TraerVId(int id);
        Task<TEntidad> Actualizar(TEntidad entidad);
        Task<TEntidad> Eliminar(TEntidad entidad);

    }
}