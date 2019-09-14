using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Platos.Dominio;
using Platos.Errores;

namespace Platos
{
    [ServiceContract]
    public interface IPlatos
    {
        [FaultContract(typeof(RepetidoException))]

        [OperationContract]
        Plato RegistrarPlato(Plato platoCrear);

        [OperationContract]
        Plato ModificarPlato(Plato platoCrear);

        [OperationContract]
        void EliminarPlato(int platoID);

        [OperationContract]
        Plato ObtenerPlatobyID(int platoID);

        [OperationContract]
        Plato ObtenerPlatobyName(string platoName);

        [OperationContract]
        List<Plato> ObtenerPlatos();
    }
}
