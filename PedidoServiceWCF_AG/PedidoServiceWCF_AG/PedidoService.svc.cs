using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PedidoServiceWCF_AG.Dominio;
using PedidoServiceWCF_AG.Persistencia;
using PedidoServiceWCF_AG.Errores;

namespace PedidoServiceWCF_AG
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PedidoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PedidoService.svc o PedidoService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PedidoService : IPedidoService
    {
        private PedidoDAO pedidoDAO = new PedidoDAO();
        public Pedido CrearPedido(Pedido pedido)
        {
            if(pedidoDAO.Obtener(pedido.Dni) != null)
            {
                throw new FaultException<ReplicadoException>(
                    new ReplicadoException() {
                        Codigo = "101",
                        Descripcion = "El Pedido ya ha sido registrado."
                    },
                    new FaultReason("Error al intentar creación.")
                );
            }
            return pedidoDAO.Crear(pedido);
        }

        public void EliminarPedido(string dni)
        {
            
        }

        public List<Pedido> ListarPedido()
        {
            return pedidoDAO.Listar();
        }

        public Pedido ModificarPedido(Pedido pedido)
        {
            return pedidoDAO.Modificar(pedido);
        }

        public Pedido ObtenerPedido(string dni)
        {
            return pedidoDAO.Obtener(dni);
        }
    }
}
