using System;
using System.Collections.Generic;

namespace CineMaxColEntity;

public partial class Horario
{
    public int Id { get; set; }

    public int? IdCine { get; set; }

    public TimeOnly? PuertasAbiertas { get; set; }

    public TimeOnly? PuertasCerradas { get; set; }

    public virtual Cine? IdCineNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
