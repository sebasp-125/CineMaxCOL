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

        // METODOS PARA MUNICIPIO, LOCALIDAD Y CINE

        // CINE
        public async Task<Cine> TraerCineExistente(int id)
        {
            return await _unitOfWork.CineR.TraerCineId(id);
        }

        public async Task<Cine> EliminarCineExistente(Cine entidad)
        {
            await _unitOfWork.CineR.Eliminar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }

        public async Task<Cine> AgregarCine(Cine entidad)
        {
            await _unitOfWork.CineR.Agregar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }
        
        public async Task<Cine> ActualizarCine(Cine entidad)
        {
            await _unitOfWork.CineR.Actualizar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }


        // LOCALIDAD
        public async Task<Ubicacion> TraerLocalidadExistente(int id)
        {
            return await _unitOfWork.UbicacionR.TraerUbicacionId(id);
        }

        public async Task<Ubicacion> EliminarLocalidadExistente(Ubicacion entidad)
        {
            await _unitOfWork.UbicacionR.Eliminar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }

        public async Task<Ubicacion> AgregarLocalidad(Ubicacion entidad)
        {
            await _unitOfWork.UbicacionR.Agregar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }
        
        public async Task<Ubicacion> ActualizarLocalidad(Ubicacion entidad)
        {
            await _unitOfWork.UbicacionR.Actualizar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }

        
        // MUNICIPIOS
        public async Task<IEnumerable<Municipio>> TraerMunicipios()
        {
            return await _unitOfWork.Municipios.Traer();
        }

        public async Task<Municipio> TraerMunicipioExistente(int id)
        {
            return await _unitOfWork.Municipios.TraerMunicipioId(id);
        }

        public async Task<Municipio> AgregarMunicipio(Municipio entidad)
        {
            await _unitOfWork.Municipios.Agregar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }
        
        public async Task<Municipio> ActualizarMunicipio(Municipio entidad)
        {
            await _unitOfWork.Municipios.Actualizar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }

        public async Task<Municipio> EliminarMunicipio(Municipio entidad)
        {
            await _unitOfWork.Municipios.Eliminar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }

    }
}