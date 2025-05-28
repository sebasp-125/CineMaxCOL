using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineMaxCOL_Web.Models
{
    public class DTO_CorreoElectronico
    {
        public string NombreTitular { get; set; }
        public string CorreoTitular { get; set; }
        public string NumeroTarjeta { get; set; }
        public string FechaExpiracion { get; set; }
        public string TipoTarjeta { get; set; }
        public string NombreUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public string Documento { get; set; }
        public string Registro { get; set; }

        public string PeliculaFuncion { get; set; }
    }
}