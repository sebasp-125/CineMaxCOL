using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class Reserva
{
    public int Id { get; set; }

    public int? IdCliente { get; set; }

    public int? IdFuncion { get; set; }

    public DateTime? FechaReserva { get; set; }

    public int? CantidadBoletos { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<HistorialCompra> HistorialCompras { get; set; } = new List<HistorialCompra>();

    public virtual Usuario? IdClienteNavigation { get; set; }

    public virtual Funcion? IdFuncionNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
