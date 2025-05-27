using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineMaxColWeb.Models
{

    // ESTO NI LO USO PERO NO LO BORRO POR SI ALGO XD
    public class Credentials
    {
        public int Id { get; set; }

        public string? CloudName { get; set; }

        public string? ApiKey { get; set; }

        public string? ApiSecret { get; set; }

        public string? Folder { get; set; }
    }
}