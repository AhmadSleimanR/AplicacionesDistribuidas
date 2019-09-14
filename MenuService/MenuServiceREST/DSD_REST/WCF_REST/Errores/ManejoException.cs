using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_REST.Errores
{
    [DataContract]
    public class ManejoException
    {
        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public string descripcion { get; set; }
    }
}