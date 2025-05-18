using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;

namespace CineMaxCOL_BILL.Service
{
    public class SelectingPositionsServices
    {

        private readonly IUnitOfWork _Unit;
        private readonly CineMaxColContext _context;
        public SelectingPositionsServices(IUnitOfWork Unit, CineMaxColContext context)
        {
            _Unit = Unit;
            _context = context;
        }

        public async Task<Funcion> Service_SelectedFuncionMovieAndMoreThings(string SalaId , string IdPelicula , string identificador){
            return await _Unit._UnitSelectingPositions.SelectedFuncionAndMoreThings(SalaId , IdPelicula  ,identificador);
        }
        
    }
}