using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClienteUnitTest
{
    [TestClass]
    public class ClienteUnitTest
    {
        [TestMethod]
        public void CreateClientes()
        {
            string jsonString = @"{
                                 ""username"":""asdasd"",
                                 ""userpass"":""admin123"",
                                 ""nombre"":""testnombre"",
                                 ""apellidos"":""unit test"",
                                 ""email"":""werty_51@hotmail.com"",
                                 ""direccion"":""test direccion"",
                                 ""dni"":""75116591""
                                }";
            RestAPIHelper<CreatedCliente> restAPI = new RestAPIHelper<CreatedCliente>();
            var restURL = restAPI.SetUrl("/api/clientes/");
            var restRequest = restAPI.CreatePostRequest(jsonString);
            var response = restAPI.GetResponse(restURL, restRequest);
            CreatedCliente content = restAPI.GetContent<CreatedCliente>(response);

            Assert.AreEqual("testnombre", content.nombre);
        }

        [TestMethod]
        public void UpdateClientes()
        {

        }

        [TestMethod]
        public void DeleteCliente()
        {

        }

        [TestMethod]
        public void FindCliente()
        {

        }
    }
}