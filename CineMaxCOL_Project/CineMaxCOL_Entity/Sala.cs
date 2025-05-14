using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class Sala
{
    public int Id { get; set; }

    public int? IdCine { get; set; }

    public string? Nombre { get; set; }

    public int? Capacidad { get; set; }

    public int? NumeroSala { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Funcion> Funcions { get; set; } = new List<Funcion>();

    public virtual Cine? IdCineNavigation { get; set; }

    public virtual ICollection<Silla> Sillas { get; set; } = new List<Silla>();
}
