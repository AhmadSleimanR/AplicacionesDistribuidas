using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClienteTest
{
    [TestClass]
    public class ClienteUnitTest
    {
        ClienteService.ClienteServiceClient proxyCliente = new ClienteService.ClienteServiceClient();

        [TestMethod]
        public void InsertarTest()
        {
            ClienteService.Cliente objCliente = new ClienteService.Cliente();
            objCliente.Username = "ahmadtest";
            objCliente.Userpass = "admin";
            objCliente.Nombre = "ahmad";
            objCliente.Apellidos = "Sleiman Romero";
            objCliente.Direccion = "Mauricio Casatti 106 dpt 301, San Borja";
            objCliente.Email = "ahmadsleimanr@gmail.com";
            objCliente.Dni = "75116593";
            proxyCliente.Insert(objCliente);
            /** Debido a que el cliente tiene una primary key identity, es necesario verificar previamente cual es el registro que desea buscar
            Mas adelante se necesitara un metodo que busque por DNI para evitarse problemas de ese tipo **/
            ClienteService.Cliente objReturn = proxyCliente.FindCliente(2);
            Assert.AreEqual(objCliente.Username, objReturn.Username);
            Assert.AreEqual(objCliente.Userpass, objReturn.Userpass);
            Assert.AreEqual(objCliente.Nombre, objReturn.Nombre);
            Assert.AreEqual(objCliente.Apellidos, objReturn.Apellidos);
            Assert.AreEqual(objCliente.Direccion, objReturn.Direccion);
            Assert.AreEqual(objCliente.Email, objReturn.Email);
            Assert.AreEqual(objCliente.Dni, objReturn.Dni);
        }

        [TestMethod]
        public void UpdateTest()
        {
            ClienteService.Cliente objCliente = new ClienteService.Cliente();
            objCliente.Clientes_id = 1;
            objCliente.Username = "admin";
            objCliente.Userpass = "admin2";
            objCliente.Nombre = "ahmad3";
            objCliente.Apellidos = "Sleiman Romero";
            objCliente.Direccion = "Mauricio Casatti 106 dpt 301, San Borja";
            objCliente.Email = "werty_51@hotmail.com";
            objCliente.Dni = "75116595";
            proxyCliente.Update(objCliente);
            ClienteService.Cliente objReturn = proxyCliente.FindCliente(1);
            Assert.AreEqual(objCliente.Username, objReturn.Username);
            Assert.AreEqual(objCliente.Userpass, objReturn.Userpass);
            Assert.AreEqual(objCliente.Nombre, objReturn.Nombre);
            Assert.AreEqual(objCliente.Apellidos, objReturn.Apellidos);
            Assert.AreEqual(objCliente.Direccion, objReturn.Direccion);
            Assert.AreEqual(objCliente.Email, objReturn.Email);
            Assert.AreEqual(objCliente.Dni, objReturn.Dni);
        }
        [TestMethod]
        public void FindTest()
        {
            ClienteService.Cliente objCliente = new ClienteService.Cliente();
            objCliente.Username = "ahmadtest";
            objCliente.Userpass = "admin";
            objCliente.Nombre = "ahmad3";
            objCliente.Apellidos = "Sleiman Romero";
            objCliente.Direccion = "Mauricio Casatti 106 dpt 301, San Borja";
            objCliente.Email = "ahmadsleimanr@gmail.com";
            objCliente.Dni = "75116593";
            ClienteService.Cliente objReturn = proxyCliente.FindCliente(2);
            Assert.AreEqual(objCliente.Username, objReturn.Username);
            Assert.AreEqual(objCliente.Userpass, objReturn.Userpass);
            Assert.AreEqual(objCliente.Nombre, objReturn.Nombre);
            Assert.AreEqual(objCliente.Apellidos, objReturn.Apellidos);
            Assert.AreEqual(objCliente.Direccion, objReturn.Direccion);
            Assert.AreEqual(objCliente.Email, objReturn.Email);
            Assert.AreEqual(objCliente.Dni, objReturn.Dni);
        }
        [TestMethod]
        public void DeleteTest()
        {
            proxyCliente.Delete(2);
            Assert.IsNotNull(proxyCliente.FindCliente(2));
        }
    }
}
