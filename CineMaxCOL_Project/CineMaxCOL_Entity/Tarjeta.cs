using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CineMaxCOL_Entity;

public partial class Tarjeta
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    [Required(ErrorMessage = "El nombre del titular es obligatorio.")]
    public string NombreTitular { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    public string CorreoElectronico { get; set; }

    [Required(ErrorMessage = "El número de tarjeta es obligatorio.")]
    public string NumeroTarjeta { get; set; }

    [Required(ErrorMessage = "La fecha de expiración es obligatoria.")]
    public DateTime  FechaExpiracion { get; set; }

    [Required(ErrorMessage = "El tipo de tarjeta es obligatorio.")]
    public string TipoTarjeta { get; set; }
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
