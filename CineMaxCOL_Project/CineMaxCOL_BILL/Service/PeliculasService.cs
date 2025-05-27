using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;

namespace CineMaxCOL_BILL.Service
{
    public class PeliculasService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PeliculasService(IUnitOfWork IUnitOfWork)
        {
            _unitOfWork = IUnitOfWork;
        }
    
        // ESTO NI SE HA TOCADO
        public async Task<IEnumerable<Pelicula>> TraerPeliculas(int id)
        {
            return await _unitOfWork.Peliculas.TraerVId(id);
        }
    }

}