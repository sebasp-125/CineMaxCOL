using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class AsientosTemporale
{
    public int Id { get; set; }

    public string? Estado { get; set; }

    public int? IdFuncion { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? ReservadoHasta { get; set; }

    public int? IdSilla { get; set; }

    public virtual Funcion? IdFuncionNavigation { get; set; }

    public virtual Silla? IdSillaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
