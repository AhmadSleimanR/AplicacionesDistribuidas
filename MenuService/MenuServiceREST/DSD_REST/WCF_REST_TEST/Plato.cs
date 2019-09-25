using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_REST_TEST
{
    class Plato
    {
        public int Id_plato { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public string Url { get; set; }
    }
}
