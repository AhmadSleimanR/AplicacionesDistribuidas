using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_REST.Dominio
{
    [DataContract]
    public class Plato
    {
        [DataMember(IsRequired = false)]
        public int Id_plato { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public decimal Precio { get; set; }

        [DataMember(IsRequired = false)]
        public string Url { get; set; }
    }
}