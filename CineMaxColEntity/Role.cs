using System;
using System.Collections.Generic;

namespace CineMaxColEntity;

public partial class Role
{
    public int Id { get; set; }

    public string? TipoRol { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
