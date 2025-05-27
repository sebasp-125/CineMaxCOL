using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineMaxColDal.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPeliculas Peliculas {get;}
        ICineComidas CineComidas {get;}
        IMunicipios Municipios {get;}
        IComidas Comidas {get;}
        ICloudinaryR CloudinaryR { get; }
        ICategorias CategoriasComida {get;}
        IPromociones Promociones { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}