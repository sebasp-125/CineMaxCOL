using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineMaxColWeb.Models
{
    public class PeliculaViewModel
    {
         public int Id { get; set; }

        public string? Titulo { get; set; }

        public string? Genero { get; set; }

        public TimeOnly? Duracion { get; set; }

        public string? Clasificacion { get; set; }

        public string? Sinopsis { get; set; }

        public bool? Estado { get; set; }

        public string? Pais { get; set; }

        public string? Director { get; set; }

        public int? IdCine { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? ImagenUrl { get; set; }
    }
}