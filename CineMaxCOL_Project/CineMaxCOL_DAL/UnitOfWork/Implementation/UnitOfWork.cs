using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.Repository.Implimentation;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;

namespace CineMaxCOL_DAL.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CineMaxColContext _context;
        private IUserRepository _userRepository;

        public UnitOfWork(CineMaxColContext context)
        {
            _context = context;
        }

        public IUserRepository _UnitUserRepository => _userRepository ??= new UserRepository(_context);

        public ILandingRepository<T> GetLandingRepository<T>() where T : class
        {
            return new LandingRepository<T>(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}