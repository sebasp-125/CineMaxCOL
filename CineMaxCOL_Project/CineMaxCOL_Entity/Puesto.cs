using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class Puesto
{
    public int Id { get; set; }

    public int IdSala { get; set; }

    public string Fila { get; set; } = null!;

    public int Columna { get; set; }

    public virtual Sala IdSalaNavigation { get; set; } = null!;
}
