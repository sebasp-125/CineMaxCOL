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
        //Here defined differents methods, Like. Interfaces and Implementation in especially about repository.
        private IUserRepository _UserRepository;
        private ILandingRepository<Pelicula> _LandingMovies;
        private CineMaxColContext _context;
        public UnitOfWork(CineMaxColContext context)
        {
            _context = context;
        }

        public IUserRepository _UnitUserRepository => _UserRepository ??= new UserRepository(_context);

        public ILandingRepository<Pelicula> PeliculaRepository => _LandingMovies ??= new LandingRepository<Pelicula>(_context);
    }
}