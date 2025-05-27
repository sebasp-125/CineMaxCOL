using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class CategoriaComidum
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? ImagenUrl { get; set; }

    public virtual ICollection<Comidum> Comida { get; set; } = new List<Comidum>();
}
