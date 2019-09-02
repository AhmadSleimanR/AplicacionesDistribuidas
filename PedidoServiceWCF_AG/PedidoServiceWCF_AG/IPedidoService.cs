using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PedidoServiceWCF_AG.Dominio;
using PedidoServiceWCF_AG.Errores;

namespace PedidoServiceWCF_AG
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPedidoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPedidoService
    {
        [FaultContract(typeof(ReplicadoException))]
        [OperationContract]
        Pedido CrearPedido(Pedido pedido);
        [OperationContract]
        Pedido ObtenerPedido(string dni);
        [OperationContract]
        Pedido ModificarPedido(Pedido pedido);
        [OperationContract]
        void EliminarPedido(string dni);
        [OperationContract]
        List<Pedido> ListarPedido();

    }
}
