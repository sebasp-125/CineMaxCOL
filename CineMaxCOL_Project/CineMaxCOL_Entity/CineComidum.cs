using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class CineComidum
{
    public int Id { get; set; }

    public int? IdCine { get; set; }

    public int? IdComida { get; set; }

    public int? Precio { get; set; }

    public int? Stock { get; set; }

    public string? DescripcionAdicional { get; set; }

    public string? Observaciones { get; set; }

    public virtual Cine? IdCineNavigation { get; set; }

    public virtual Comidum? IdComidaNavigation { get; set; }

    public virtual ICollection<PromocionComidum> PromocionComida { get; set; } = new List<PromocionComidum>();
}
