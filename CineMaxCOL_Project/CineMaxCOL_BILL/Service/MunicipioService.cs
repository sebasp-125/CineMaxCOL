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

        // METODOS
        public async Task<Comidum> TraerPlatoGeneralId(int id)
        {
            return await _unitOfWork.Comidas.TraerComidaGeneralId(id);
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