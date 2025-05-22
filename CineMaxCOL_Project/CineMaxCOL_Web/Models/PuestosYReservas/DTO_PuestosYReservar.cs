using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_Entity;

namespace CineMaxCOL_Web.Models.PuestosYReservas
{
    public class DTO_PuestosYReservar
    {
        public Funcion funcionDto { get; set; }
        public List<SillasPorFuncion> sillasPorFuncions { get; set; }
    }
}