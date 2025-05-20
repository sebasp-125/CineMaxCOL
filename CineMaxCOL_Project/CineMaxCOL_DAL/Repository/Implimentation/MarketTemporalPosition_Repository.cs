using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_Entity;

namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class MarketTemporalPosition_Repository : IMarketTemporalPosition_Repository<AsientosTemporale>
    {
        private readonly CineMaxColContext _context;
        public MarketTemporalPosition_Repository(CineMaxColContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTemporalRepository(AsientosTemporale asientosTemporale)
        {
            try
            {
                await _context.AsientosTemporales.AddAsync(asientosTemporale);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}