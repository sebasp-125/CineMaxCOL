using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineMaxCOL_DAL.Repository.Interface
{
    public interface ILandingRepository<T> : IRepository<T> where T : class 
    {
        
    }
}