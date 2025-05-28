using CineMaxCol_DAL.Interface;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_Entity;

namespace CineMaxCOL_DAL.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        ISelectingPositions<Funcion> _UnitSelectingPositions { get; }
        IUserRepository _UnitUserRepository { get; }
        ILandingRepository<T> GetLandingRepository<T>() where T : class;
        IDetailsSelectedMovie<T> GetDetailsMoviesAndCine<T>() where T : class;
        ISendEmail _UnitSendEmail { get; }

        //All relacionated Payment/BuyTickets
        IPaymentBuyTickets<T> _UnitPaymentBuyTicktes<T>() where T : class;

        //Just everything about MarketPositionsTemporal
        IMarketTemporalPosition_Repository<AsientosTemporale> _UnitTemporalPositions { get; }


        //Andres
        IPeliculas Peliculas {get;}
        ICineComidas CineComidas {get;}
        IMunicipios Municipios {get;}
        IComidas Comidas {get;}
        ICloudinaryR CloudinaryR { get; }
        ICategorias CategoriasComida {get;}
        IPromociones Promociones { get; }
        Task SaveChangesAsync();

    }
}