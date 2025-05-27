using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;

namespace CineMaxCOL_BILL.Service
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