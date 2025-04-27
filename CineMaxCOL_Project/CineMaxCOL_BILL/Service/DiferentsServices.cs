using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_Entity;

namespace CineMaxCOL_BILL.Service
{
    public class DiferentsServices
    {
        private readonly IRepository<Usuario> _Repository;
        public DiferentsServices(IRepository<Usuario> Repository)
        {
            _Repository = Repository;
        }

        public async Task<List<Usuario>> GetAll_Servies()
        {
            return await _Repository.GetAll();
        }
    }
}