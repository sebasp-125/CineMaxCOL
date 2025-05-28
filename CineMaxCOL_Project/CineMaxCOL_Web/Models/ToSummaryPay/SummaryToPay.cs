using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_Entity;

namespace CineMaxCOL_Web.Models.ToSummaryPay
{
    public class SummaryToPay
    {
        public Funcion funcion { get; set; }
        public Tarjetum UsuarioByTarjeta { get; set; }
    }
}