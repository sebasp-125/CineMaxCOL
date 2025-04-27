using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class Municipio
{
    public int Id { get; set; }

    public string? NombreMunicipio { get; set; }

    public virtual ICollection<Ubicacion> Ubicacions { get; set; } = new List<Ubicacion>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
