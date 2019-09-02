using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PedidoServiceWCF_AG.Dominio
{
    [DataContract]
    public class Pedido
    {
        [DataMember]
        public string Dni { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public double SubTotal { get; set; }

        [DataMember]
        public double Igv { get; set; }

        [DataMember]
        public double Total { get; set; }
    }
}