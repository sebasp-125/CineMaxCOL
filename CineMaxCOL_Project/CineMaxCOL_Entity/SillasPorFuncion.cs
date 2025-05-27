using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class SillasPorFuncion
{
    public int Id { get; set; }

    public int IdFuncion { get; set; }

    public int IdSilla { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime? ReservadoHasta { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Funcion IdFuncionNavigation { get; set; } = null!;

    public virtual Silla IdSillaNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
