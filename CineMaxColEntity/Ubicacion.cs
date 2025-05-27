using System;
using System.Collections.Generic;

namespace CineMaxColEntity;

public partial class Ubicacion
{
    public int Id { get; set; }

    public int? IdMunicipio { get; set; }

    public string? Direccion { get; set; }

    public string? Localidad { get; set; }

    public virtual ICollection<Cine> Cines { get; set; } = new List<Cine>();

    public virtual Municipio? IdMunicipioNavigation { get; set; }
}
