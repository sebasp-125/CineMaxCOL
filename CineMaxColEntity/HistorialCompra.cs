using System;
using System.Collections.Generic;

namespace CineMaxColEntity;

public partial class HistorialCompra
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdReserva { get; set; }

    public virtual Reserva? IdReservaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
