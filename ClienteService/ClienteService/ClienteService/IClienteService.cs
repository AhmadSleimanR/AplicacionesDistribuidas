using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClienteService
{
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        String Insert(Cliente cliente);
        [OperationContract]
        string Update(Cliente cliente);
        [OperationContract]
        Cliente FindCliente(int dni);
        [OperationContract]
        String Delete(int dni);

        [OperationContract]
      List<Cliente> ListarClientes();
    }

    [DataContract]
    public class Cliente {
        int clientes_id;
        string username;
        string userpass;
        string nombre;
        string apellidos;
        string email;
        string direccion;
        string dni;
        string telefono;

        [DataMember]
        public int Clientes_id
        {
            get { return clientes_id; }
            set { clientes_id = value; }
        }
        [DataMember]
        public String Username
        {
            get { return username; }
            set { username = value; }
        }
        [DataMember]
        public String Userpass
        {
            get { return userpass; }
            set { userpass = value; }
        }
        [DataMember]
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        [DataMember]
        public String Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        [DataMember]
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        [DataMember]
        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        [DataMember]
        public String Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        [DataMember]
        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
    }

}
