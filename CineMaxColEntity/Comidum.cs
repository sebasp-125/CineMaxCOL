using System;
using System.Collections.Generic;

namespace CineMaxColEntity;

public partial class Comidum
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripción { get; set; }

    public string? ImagenUrl { get; set; }

    public int? CategoriaId { get; set; }

    public virtual CategoriaComidum? Categoria { get; set; }

    public virtual ICollection<CineComidum> CineComida { get; set; } = new List<CineComidum>();
}
