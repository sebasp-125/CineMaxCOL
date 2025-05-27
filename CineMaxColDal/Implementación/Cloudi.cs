using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxColDal.DBContext;
using CineMaxColDal.Interfaces;
using CineMaxColEntity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxColDal.Implementación
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