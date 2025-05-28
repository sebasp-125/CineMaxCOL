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

        public async Task<IEnumerable<Pelicula>> TraerPeliculasPorId(int id)
        {
            return await _unitOfWork.Peliculas.TraerVId(id);
        }
        
        public async Task<IEnumerable<Pelicula>> TraerTodasPelis()
        {
            return await _unitOfWork.Peliculas.Traer();
        }

        public async Task<Pelicula> TraerPeliculaExistente(int id)
        {
            return await _unitOfWork.Peliculas.TraerPeliculaId(id);
        }

        public async Task<Pelicula> AgregarPelicula(Pelicula entidad)
        {
            await _unitOfWork.Peliculas.Agregar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }
        
        public async Task<Pelicula> ActualizarPelicula(Pelicula entidad)
        {
            await _unitOfWork.Peliculas.Actualizar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }

        public async Task<Pelicula> EliminarPelicula(Pelicula entidad)
        {
            await _unitOfWork.Peliculas.Eliminar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }
    }

}