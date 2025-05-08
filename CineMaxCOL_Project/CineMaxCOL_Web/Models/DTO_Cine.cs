using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineMaxCOL_Web.Models
{
    public class DTO_Cine
    {

    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? Telefono { get; set; }
    public DTO_Ubicacion? Ubicacion { get; set; }


    }
}