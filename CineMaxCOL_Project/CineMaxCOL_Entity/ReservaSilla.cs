using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class ReservaSilla
{
    public int Id { get; set; }

    public int IdReserva { get; set; }

    public int IdSilla { get; set; }

    public virtual Reserva IdReservaNavigation { get; set; } = null!;

    public virtual Silla IdSillaNavigation { get; set; } = null!;
}
