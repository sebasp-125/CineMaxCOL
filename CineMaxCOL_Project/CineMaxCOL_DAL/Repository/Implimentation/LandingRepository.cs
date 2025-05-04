using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class LandingRepository<T> : ILandingRepository<T> where T : class
    {
        private readonly CineMaxColContext _context;
        private readonly DbSet<T> _dbset;

        public LandingRepository(CineMaxColContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        public async Task<List<T>> GetAll()
        {
            try{
                return await _dbset.ToListAsync();
            }catch{
                return null;
            }
        }
    }
}