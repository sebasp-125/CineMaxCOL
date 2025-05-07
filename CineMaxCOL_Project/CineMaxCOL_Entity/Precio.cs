using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class Precio
{
    public int Id { get; set; }

    public int? HoraInicio { get; set; }

    public int? HoraFin { get; set; }

    public decimal? Precio1 { get; set; }

    public int? IdDiaSemana { get; set; }

    public virtual DiasSemana? IdDiaSemanaNavigation { get; set; }
}
