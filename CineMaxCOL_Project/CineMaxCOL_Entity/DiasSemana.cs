using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class DiasSemana
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Precio> Precios { get; set; } = new List<Precio>();
}
