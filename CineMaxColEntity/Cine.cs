using System;
using System.Collections.Generic;

namespace CineMaxColEntity;

public partial class Cine
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? IdUbicacion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public int? IdEmpleado { get; set; }

    public virtual ICollection<CineComidum> CineComida { get; set; } = new List<CineComidum>();

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Ubicacion? IdUbicacionNavigation { get; set; }

    public virtual ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();

    public virtual ICollection<Sala> Salas { get; set; } = new List<Sala>();
}
