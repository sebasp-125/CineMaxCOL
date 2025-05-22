using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;

namespace CineMaxCOL_BILL.Service
{
    public class MarketTemporalService
    {
        IUnitOfWork _Unit;
        public MarketTemporalService(IUnitOfWork Unit)
        {
            _Unit = Unit;
        }
        public async Task<bool> MarketTemporalPosition_Services(AsientosTemporale asientosTemporale)
        {
            var response = await _Unit._UnitTemporalPositions.AddTemporalRepository(asientosTemporale);
            if (!response)
                return false;
            return true;
        }
    }
}