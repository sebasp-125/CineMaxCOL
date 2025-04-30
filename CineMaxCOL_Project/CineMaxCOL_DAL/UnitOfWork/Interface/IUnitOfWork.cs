using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.Repository.Interface;

namespace CineMaxCOL_DAL.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository _UnitUserRepository {get;}
        
    }
}