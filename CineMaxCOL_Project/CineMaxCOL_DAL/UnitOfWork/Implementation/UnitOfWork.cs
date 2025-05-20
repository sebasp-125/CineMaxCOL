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
        private ISendEmail _SendEmailRepository;
        private ISelectingPositions<Funcion> _SelectingPositions;
        private IMarketTemporalPosition_Repository<AsientosTemporale> _MarketTemporalPositions;

        public UnitOfWork(CineMaxColContext context)
        {
            _context = context;
        }

        public IUserRepository _UnitUserRepository => _userRepository ??= new UserRepository(_context);

        public ISelectingPositions<Funcion> _UnitSelectingPositions => _SelectingPositions ??= new SelectingPositionsRepository(_context);

        public ISendEmail _UnitSendEmail => _SendEmailRepository ??= new SendEmail(_context);

        public IMarketTemporalPosition_Repository<AsientosTemporale> _UnitTemporalPositions => _MarketTemporalPositions ??= new MarketTemporalPosition_Repository(_context);

        public IDetailsSelectedMovie<T> GetDetailsMoviesAndCine<T>() where T : class
        {
            return new DetailsSelectedMovie<T>(_context);
        }

        public ILandingRepository<T> GetLandingRepository<T>() where T : class
        {
            return new LandingRepository<T>(_context);
        }
        public IPaymentBuyTickets<T> _UnitPaymentBuyTicktes<T>() where T : class
        {
            return new PaymentBuyTickets<T>(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}