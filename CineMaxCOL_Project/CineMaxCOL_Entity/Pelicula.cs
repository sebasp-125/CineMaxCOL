using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class Pelicula
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

    public string? Identificador { get; set; }

    public virtual ICollection<Funcion> Funcions { get; set; } = new List<Funcion>();

    public virtual Cine? IdCineNavigation { get; set; }
}
