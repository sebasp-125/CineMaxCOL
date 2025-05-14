using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class Silla
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public bool Ocupado { get; set; }

    public int SalaId { get; set; }

    public virtual Sala Sala { get; set; } = null!;
}
