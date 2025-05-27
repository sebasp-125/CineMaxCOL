using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class Silla
{
    public int Id { get; set; }

    public string Fila { get; set; } = null!;

    public int Numero { get; set; }

    public int? IdSala { get; set; }

    public virtual ICollection<AsientosTemporale> AsientosTemporales { get; set; } = new List<AsientosTemporale>();

    public virtual Sala? IdSalaNavigation { get; set; }

    public virtual ICollection<SillasPorFuncion> SillasPorFuncions { get; set; } = new List<SillasPorFuncion>();
}
