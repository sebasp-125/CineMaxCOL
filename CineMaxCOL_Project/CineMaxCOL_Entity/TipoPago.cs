using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class TipoPago
{
    public int Id { get; set; }

    public string? NombreTipo { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
