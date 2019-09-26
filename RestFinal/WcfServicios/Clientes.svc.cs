using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfServicios.Dominio;
using WcfServicios.Errores;
using WcfServicios.Helper;
using WcfServicios.Persistencia;

namespace WcfServicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Clientes" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Clientes.svc o Clientes.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Clientes : IClientes
    {
        private ClienteDAO clienteDAO = new ClienteDAO();
        public Cliente CrearCliente(Cliente clienteACrear)
        {
            Cliente clienteExistente = clienteDAO.Obtener(clienteACrear.Dni );
            if (clienteExistente != null)
            {
                throw new WebFaultException<ClienteException>(new ClienteException()
                {
                    Codigo = 102,
                    Descripcion = "Este DNI ya esta registrado",
                }, HttpStatusCode.Conflict);
            }

            Cliente emailExistente = clienteDAO.VerifcarEmail(clienteACrear.Email);
            if (emailExistente != null)
            {
                throw new WebFaultException<ClienteException>(new ClienteException()
                {
                    Codigo = 103,
                    Descripcion = "Este email ya esta registrado",
                }, HttpStatusCode.Conflict);
            }

            Random random = new Random();
            int randomNumber = random.Next(10000, 99999);


            clienteACrear.Codigo = randomNumber.ToString ();




            return clienteDAO.Crear(clienteACrear);
        }
        public void EliminarCliente(string id)
        {
            clienteDAO.Eliminar(int.Parse(id));
        }
        public List<Cliente> ListarCliente()
        {
            return clienteDAO.Listar();
        }
        public Cliente ModificarCliente(Cliente clienteAModificar)
        {
            return clienteDAO.Modificar(clienteAModificar);
        }
        public Cliente ObtenerCliente(string dni)
        {
            return clienteDAO.Obtener(dni);
        }
        public Cliente VerificarCliente(Cliente clienteVerificar)
        {

            Cliente clienteExistente = clienteDAO.VerificarCodigo(clienteVerificar.Dni , clienteVerificar.Codigo);
            if (clienteExistente == null)
            {
                throw new WebFaultException<ClienteException>(new ClienteException()
                {
                    Codigo = 105,
                    Descripcion = "Codigo de verificacion incorrecto",
                }, HttpStatusCode.Conflict);
            }



                        return clienteDAO.Verificado(clienteVerificar.Dni);


        }

    }
}
