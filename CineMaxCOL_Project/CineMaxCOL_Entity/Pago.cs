using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class Pago
{
    public int Id { get; set; }

    public int? IdReserva { get; set; }

    public decimal? Monto { get; set; }

    public int? IdTipoPago { get; set; }

    public DateTime? FechaPago { get; set; }

    public virtual Reserva? IdReservaNavigation { get; set; }

    public virtual TipoPago? IdTipoPagoNavigation { get; set; }
}
