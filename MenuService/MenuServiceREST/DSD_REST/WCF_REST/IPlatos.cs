using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_REST.Dominio;
using WCF_REST.Errores;

namespace WCF_REST
{
    [ServiceContract]
    public interface IPlatos
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate ="Platos",ResponseFormat = WebMessageFormat.Json)]
        Plato RegistrarPlato(Plato platoCrear);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Platos", ResponseFormat = WebMessageFormat.Json)]
        Plato ModificarPlato(Plato platoCrear);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Platos/{platoID}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarPlato(string platoID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Platos/Nombre/{platoName}", ResponseFormat = WebMessageFormat.Json)]
        Plato ObtenerPlatobyName(string platoName);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Platos/{platoID}", ResponseFormat = WebMessageFormat.Json)]
        Plato ObtenerPlatobyID(string platoID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Platos", ResponseFormat = WebMessageFormat.Json)]
        List<Plato> ObtenerPlatos();
    }
}
