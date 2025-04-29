using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly CineMaxColContext _context;
        public Repository(CineMaxColContext Context)
        {
            _context = Context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> Add(T t)
        {
            try
            {
                await _dbSet.AddAsync(t);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
    }
}