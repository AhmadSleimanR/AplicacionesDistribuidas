﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfServicios.Errores
{
    public class ClienteException
    {
        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public string Descripcion { get; set; }
    }
}