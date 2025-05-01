using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class UserRepository : IUserRepository
    {
        private readonly CineMaxColContext _context;
        public UserRepository(CineMaxColContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Usuario t)
        {
            try
            {
                await _context.Usuarios.AddAsync(t);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}