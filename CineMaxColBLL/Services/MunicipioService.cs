using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxColDal.Interfaces;
using CineMaxColEntity;

namespace CineMaxColBLL.Services
{
    public class MunicipioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MunicipioService(IUnitOfWork IUnitOfWork)
        {
            _unitOfWork = IUnitOfWork;
        }

        // ESTO NI SE HA TOCADO
        public async Task<IEnumerable<Municipio>> TraerMunicipios()
        {
            return await _unitOfWork.Municipios.Traer();
        }

    }
}