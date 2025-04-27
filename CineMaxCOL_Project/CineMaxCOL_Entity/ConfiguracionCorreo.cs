using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class ConfiguracionCorreo
{
    public int Id { get; set; }

    public string? Recurso { get; set; }

    public string? Propiedad { get; set; }

    public string? Valor { get; set; }
}
