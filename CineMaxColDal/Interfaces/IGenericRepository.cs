using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineMaxColDal.Interfaces
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