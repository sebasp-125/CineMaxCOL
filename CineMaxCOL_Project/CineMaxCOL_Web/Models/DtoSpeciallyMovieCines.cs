using System;
using CineMaxCOL_Entity;

namespace CineMaxCOL_Web.Models
{
    // DTO para representar una película junto con el cine donde se proyecta
    public class DtoSpeciallyMovieCines
    {
        public string? Titulo { get; set; }
        public string? Genero { get; set; }
        public string? Clasificacion { get; set; }
        public TimeOnly? Duracion { get; set; }

        public Cine? Cine { get; set; }
    }
}
