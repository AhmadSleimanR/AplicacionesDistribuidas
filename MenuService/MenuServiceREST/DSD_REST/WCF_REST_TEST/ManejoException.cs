using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_REST_TEST
{
    public class ManejoException
    {
        public int codigo { get; set; }

        public string descripcion { get; set; }
    }
}