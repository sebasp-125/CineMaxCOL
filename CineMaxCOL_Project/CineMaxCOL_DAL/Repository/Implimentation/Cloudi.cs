using CineMaxCol_DAL.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class CloudinaryR : ICloudinaryR
    {
        private readonly CineMaxColContext _dbcontext;

        public CloudinaryR(CineMaxColContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<ConfiguracionCloud?> TraerCredenciales()
        {
            return await _dbcontext.Set<ConfiguracionCloud>().FirstOrDefaultAsync();
        }
    }
}