using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.Repository.Implimentation;
using CineMaxCOL_Entity;

namespace CineMaxCOL_DAL.Repository.Interface
{
    public interface IDetailsSelectedMovie<T>
    {
        Task<List<Funcion>> GetCinesWithMovies(string Identificador);
        Task<Funcion> GetSpeciallyFuncion(int id);
    }
}