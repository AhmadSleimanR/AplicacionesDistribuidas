using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Cliente
    {
        public String Dni { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }
        public String Direccion { get; set; }
        public String UserName { get; set; }
        public String UserPass { get; set; }

        public String Codigo { get; set; }
        public int Verificado { get; set; }

    }
}