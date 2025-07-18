﻿using System;
using System.Collections.Generic;

namespace CineMaxCOL_Entity;

public partial class Usuario
{
    public int Id { get; set; }

    public int? IdMunicipio { get; set; }

    public string? FullName { get; set; }

    public string? Dni { get; set; }

    public string? Email { get; set; }

    public bool? IsActivated { get; set; }

    public int? IdRol { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<AsientosTemporale> AsientosTemporales { get; set; } = new List<AsientosTemporale>();

    public virtual ICollection<HistorialCompra> HistorialCompras { get; set; } = new List<HistorialCompra>();

    public virtual Municipio? IdMunicipioNavigation { get; set; }

    public virtual Role? IdRolNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<SillasPorFuncion> SillasPorFuncions { get; set; } = new List<SillasPorFuncion>();

    public virtual ICollection<Tarjetum> Tarjeta { get; set; } = new List<Tarjetum>();
}
