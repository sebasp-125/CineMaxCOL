using CineMaxCol_DAL.Interface;
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

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();

        }


        //Andres
        private readonly IPeliculas? _peliculasRepository; 
        private readonly IMunicipios? _municipioRepository;
        private readonly ICineComidas? _cineComidasRepository;
        private readonly ICategorias? _categoriaRepository;
        private readonly IComidas? _comidasRepository;
        private readonly ICloudinaryR? _cloudinaryRepository;
        private readonly IPromociones? _promocionesRepository;

        public IPeliculas Peliculas => _peliculasRepository ?? new Peliculas(_context);
        public ICineComidas CineComidas => _cineComidasRepository ?? new CineComidas(_context);
        public IMunicipios Municipios => _municipioRepository ?? new Municipios(_context);
        public IComidas Comidas => _comidasRepository ?? new Comidas(_context);

        public ICategorias CategoriasComida => _categoriaRepository ?? new CategoriasComida(_context);

        public ICloudinaryR CloudinaryR => _cloudinaryRepository ?? new CloudinaryR(_context);
        public IPromociones Promociones => _promocionesRepository ?? new Promociones(_context);
    }

}