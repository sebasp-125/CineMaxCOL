using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class Lavadora
{
    public int Id { get; set; }

    public string? Brand { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
