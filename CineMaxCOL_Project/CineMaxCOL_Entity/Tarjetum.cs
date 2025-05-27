using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class Tarjetum
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public string? NombreTitular { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? NumeroTarjeta { get; set; }

    public DateOnly? FechaExpiracion { get; set; }

    public string? TipoTarjeta { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
