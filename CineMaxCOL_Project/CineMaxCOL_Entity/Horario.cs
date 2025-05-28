using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class Horario
{
    public int Id { get; set; }

    public int? IdCine { get; set; }

    public TimeOnly? PuertasAbiertas { get; set; }

    public TimeOnly? PuertasCerradas { get; set; }

    public virtual Cine? IdCineNavigation { get; set; }
}
