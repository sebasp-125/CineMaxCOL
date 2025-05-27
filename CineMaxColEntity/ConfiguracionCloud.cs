using System;
using System.Collections.Generic;

namespace CineMaxColEntity;

public partial class ConfiguracionCloud
{
    public int Id { get; set; }

    public string? CloudName { get; set; }

    public string? ApiKey { get; set; }

    public string? ApiSecret { get; set; }

    public string? Folder { get; set; }
}
