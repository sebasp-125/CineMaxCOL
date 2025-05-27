using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxColEntity;

namespace CineMaxColWeb.Models
{
    public class ComidaViewModel
    {
        public string TipoEntidad { get; set; } = null!; // Para identificar dónde entrar al controldaor según el tipo de entidad categoria, comida, cinecomida, promocion... Esto para usar los mismos controladores

        public IEnumerable<CineComidum>? CineComidas { get; set; } //Para mostrar lista de comidas por cine
        public CineComidum CineComida_s { get; set; } = new(); // Para mandar comida de cine

        public IEnumerable<Comidum>? Comidas { get; set; } // Para mostrar lista de comidas generales
        public Comidum ComidaGeneral_s { get; set; } = new(); // Para mandar una comida nueva general

        public IEnumerable<CategoriaComidum>? Categorias { get; set; } // Para mostrar lista de categorias completa
        public CategoriaComidum Categoria_s { get; set; } = new(); // Para mandar una categoria nueva

        public PromocionComidum Promos_s { get; set; } = new(); // Para ingresar una promoción nueva
        
        public IEnumerable<Municipio>? Municipios { get; set; } // Para mostrar lista de municipios completa
        
    }
}