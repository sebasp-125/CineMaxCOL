using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class Category
{
    public int Id { get; set; }

    public string? NameCategory { get; set; }

    public virtual ICollection<Lavadora> Lavadoras { get; set; } = new List<Lavadora>();
}
