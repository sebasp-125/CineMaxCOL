using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.Repository.Implimentation;

namespace CineMaxCOL_DAL.Repository.Interface
{
    public interface IDetailsSelectedMovie
    {
        Task<List<DetailsSelectedMovie>> GetCineAndDiferentInformation();
    }
}