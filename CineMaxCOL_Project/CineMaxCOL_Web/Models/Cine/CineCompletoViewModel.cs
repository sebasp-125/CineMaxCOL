using CineMaxCOL_Entity;

namespace CineMaxCOL_Web.Models.Cine
{
    public class CineCompletoViewModel
    {
        public IEnumerable<Municipio>? Municipios_Lista { get; set; }
        public IEnumerable<Pelicula>? Peliculas_Lista { get; set; }

        public Ubicacion? Ubicacion_s { get; set; } = new();
        public Municipio? Municipio_s { get; set; } = new();
        public CineMaxCOL_Entity.Cine Cine_s { get; set; } = new();
    }
}