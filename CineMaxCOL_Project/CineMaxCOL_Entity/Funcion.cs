using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class Funcion
{
    public int Id { get; set; }

    public int? IdSala { get; set; }

    public int? IdPelicula { get; set; }

    public DateTime? FechaHora { get; set; }

    public decimal? Precio { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? IdentificadorMovies { get; set; }

    public virtual Pelicula? IdPeliculaNavigation { get; set; }

    public virtual Sala? IdSalaNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
