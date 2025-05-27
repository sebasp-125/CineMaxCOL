using System;
using System.Collections.Generic;

namespace CineMaxColEntity;

public partial class PromocionComidum
{
    public int Id { get; set; }

    public int? IdCineComida { get; set; }

    public int? DescuentoPorcentaje { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public virtual CineComidum? IdCineComidaNavigation { get; set; }
}
