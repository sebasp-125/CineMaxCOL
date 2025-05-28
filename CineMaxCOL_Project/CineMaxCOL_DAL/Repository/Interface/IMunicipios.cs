using CineMaxCOL_Entity;

namespace CineMaxCol_DAL.Interface
{
    public interface IMunicipios : IGenericRepository<Municipio>
    {
        Task<Municipio> TraerMunicipioId(int id);
    }
}