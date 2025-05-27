using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;

namespace CineMaxCOL_BILL.Service
{
    public class CineComidaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CineComidaService(IUnitOfWork IUnitOfWork)
        {
            _unitOfWork = IUnitOfWork;
        }

        // AQUI SEBAS HUBIERA SIDO BUENO IMPLEMENTAR LO QUE HICISTE DE LOS METODOS PARA QUE SEAN MÁS GENERICOS Y EVITAR ESTAS COSAS CON LOS REPOSITORIOS

        // FUNCIONES PARA LA COMIDA GENERAL
        public async Task<IEnumerable<Comidum>> TraerComidaGeneral()
        {
            return await _unitOfWork.Comidas.Traer();
        }
        public async Task<Comidum> TraerPlatoGeneralId(int id)
        {
            return await _unitOfWork.Comidas.TraerComidaGeneralId(id);
        }

        public async Task<Comidum> AgregarComidaGeneral(Comidum entidad)
        {
            await _unitOfWork.Comidas.Agregar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }
        
        public async Task<Comidum> ActualizarComidaGeneral(Comidum entidad)
        {
            await _unitOfWork.Comidas.Actualizar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }

        public async Task<Comidum> EliminarComidaGeneral(Comidum entidad)
        {
            await _unitOfWork.Comidas.Eliminar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }


 
        // FUNCIONES PARA LA COMIDA DE UN CINE EN ESPECIFICO
        public async Task<IEnumerable<CineComidum>> TraerComida(int id)
        {
            return await _unitOfWork.CineComidas.TraerVId(id);
        }

        public async Task<CineComidum> TraerPlatoId(int id)
        {
            return await _unitOfWork.CineComidas.TraerPlatoId(id);
        }

        public async Task<CineComidum> AgregarComida(CineComidum entidad)
        {
            await _unitOfWork.CineComidas.Agregar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }
        
        public async Task<CineComidum> ActualizarComida(CineComidum entidad)
        {
            await _unitOfWork.CineComidas.Actualizar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }
        
        public async Task<CineComidum> EliminarComida(CineComidum entidad)
        {
            await _unitOfWork.CineComidas.Eliminar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }
        


        // FUNCIONES PARA LAS CATEGORIAS
        public async Task<IEnumerable<CategoriaComidum>> TraerCategorias()
        {
            return await _unitOfWork.CategoriasComida.Traer();
        }

        public async Task<CategoriaComidum> TraerCategoriaId(int id)
        {
            return await _unitOfWork.CategoriasComida.TraerCategoriaId(id);
        }

        public async Task<CategoriaComidum> AgregarCategoriaComida(CategoriaComidum entidad)
        {
            await _unitOfWork.CategoriasComida.Agregar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }

        public async Task<CategoriaComidum> ActualizarCategoria(CategoriaComidum entidad)
        {
            await _unitOfWork.CategoriasComida.Actualizar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }

        public async Task<CategoriaComidum> EliminarComidaCategoria(CategoriaComidum entidad)
        {
            await _unitOfWork.CategoriasComida.Eliminar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }


        // FUNCIONES PARA LAS PROMOCIONES
        public async Task<PromocionComidum> TraerPromo(int id)
        {
            return await _unitOfWork.Promociones.TraerPromoId(id);
        }
        public async Task<PromocionComidum> AgregarPromo(PromocionComidum entidad)
        {
            await _unitOfWork.Promociones.Agregar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }

        public async Task<PromocionComidum> ActualizarPromo(PromocionComidum entidad)
        {
            await _unitOfWork.Promociones.Actualizar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }

        public async Task<PromocionComidum> EliminarPromo(PromocionComidum entidad)
        {
            await _unitOfWork.Promociones.Eliminar(entidad);
            await _unitOfWork.SaveChangesAsync();
            return entidad;
        }
    }
}