using CineMaxCOL_Entity;

namespace CineMaxCol_DAL.Interface
{
    public interface ICloudinaryR
    {
        Task<ConfiguracionCloud?> TraerCredenciales();
    }

}