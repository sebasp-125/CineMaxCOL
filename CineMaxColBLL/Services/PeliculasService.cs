using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxColDal.Interfaces;
using CineMaxColEntity;

namespace CineMaxColBLL.Services
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