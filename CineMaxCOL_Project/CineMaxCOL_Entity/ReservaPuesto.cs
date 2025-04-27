using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class ReservaPuesto
{
    public int Id { get; set; }

    public int IdReserva { get; set; }

    public int IdPuesto { get; set; }

    public virtual Puesto IdPuestoNavigation { get; set; } = null!;

    public virtual Reserva IdReservaNavigation { get; set; } = null!;
}
