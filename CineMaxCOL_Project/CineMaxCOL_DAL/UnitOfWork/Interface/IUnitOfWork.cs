using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    }
}