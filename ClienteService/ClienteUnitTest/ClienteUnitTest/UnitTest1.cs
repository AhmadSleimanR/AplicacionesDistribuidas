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
            string jsonString = @"{
                                 ""id"":""1"",
                                 ""username"":""UPDATE"",
                                 ""userpass"":""admin123"",
                                 ""nombre"":""testnombre"",
                                 ""apellidos"":""unit test"",
                                 ""email"":""werty_51@hotmail.com"",
                                 ""direccion"":""test direccion"",
                                 ""dni"":""75116591""
                                }";
            RestAPIHelper<CreatedCliente> restAPI = new RestAPIHelper<CreatedCliente>();
            var restURL = restAPI.SetUrl("/api/clientes/1");
            var restRequest = restAPI.CreatePutRequest(jsonString);
            var response = restAPI.GetResponse(restURL, restRequest);
            CreatedCliente content = restAPI.GetContent<CreatedCliente>(response);
            Assert.AreEqual("UPDATE", content.username);
        }

        [TestMethod]
        public void DeleteCliente()
        {
            RestAPIHelper<CreatedCliente> restAPI = new RestAPIHelper<CreatedCliente>();
            var restURL = restAPI.SetUrl("/api/clientes/8");
            var restRequest = restAPI.CreateDeleteRequest();
        }

        [TestMethod]
        public void FindCliente()
        {
            RestAPIHelper<CreatedCliente> restAPI = new RestAPIHelper<CreatedCliente>();
            var restURL = restAPI.SetUrl("/api/clientes/8");
            var restRequest = restAPI.CreateGetRequest();
            var response = restAPI.GetResponse(restURL, restRequest);
            CreatedCliente content = restAPI.GetContent<CreatedCliente>(response);
            Assert.AreEqual("Test", content.nombre);
        }
    }
}