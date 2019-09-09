using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace PedidoServiceWCF_AG.Errores
{
    [DataContract]
    public class ReplicadoException
    {
        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Descripcion { get; set; }
    }
}