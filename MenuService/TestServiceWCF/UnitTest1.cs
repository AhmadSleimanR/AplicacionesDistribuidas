using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using System.Diagnostics;

namespace TestServiceWCF
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCrear()
        {
            try
            {
                PlatosServ.PlatosClient platosClient = new PlatosServ.PlatosClient();

                PlatosServ.Plato plato = platosClient.RegistrarPlato(
                    new PlatosServ.Plato
                    {
                        Descripcion = "Arroz  Chaufa",
                        Precio = (decimal)17.5,
                        Url = "https://developersonline2019.net/resources/21.png"
                    }
                );

                Assert.AreEqual("Arroz  Chaufa", plato.Descripcion);
                Assert.AreEqual((decimal)17.5, plato.Precio);
                Assert.AreEqual("https://developersonline2019.net/resources/21.png", plato.Url);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }
            

        }
        [TestMethod]
        public void TestModificar()
        {
            try
            {
                PlatosServ.PlatosClient platosClient = new PlatosServ.PlatosClient();

                PlatosServ.Plato plato = platosClient.ModificarPlato(
                    new PlatosServ.Plato
                    {
                        Id_plato = 2015,
                        Descripcion = "Arroz Chaufa",
                        Precio = (decimal)20.50,
                        Url = "https://developersonline2019.net/resources/21.png"
                    }
                );

                Assert.AreEqual("Arroz Chaufa", plato.Descripcion);
                Assert.AreEqual((decimal)20.50, plato.Precio);
                Assert.AreEqual("https://developersonline2019.net/resources/21.png", plato.Url);
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message.ToString());
            }
            

        }
        [TestMethod]
        public void TestRegistroRepetido()
        {
            PlatosServ.PlatosClient platosClient = new PlatosServ.PlatosClient();
            try
            {
                PlatosServ.Plato plato = platosClient.RegistrarPlato(
                    new PlatosServ.Plato
                    {
                        Descripcion = "Arroz Chaufa",
                        Precio = (decimal)17.50,
                        Url = "https://developersonline2019.net/resources/21.png"
                    }
                );
            }
            catch (FaultException<PlatosServ.RepetidoException> err)
            {
                Assert.AreEqual("Error al registrar", err.Reason.ToString());
                Assert.AreEqual(err.Detail.codigo, "101");
                Assert.AreEqual(err.Detail.descripcion, "El plato que desea registrar ya existe");
            }
            
        }
        [TestMethod]
        public void TestEliminarRegistro()
        {
            try
            {
                PlatosServ.PlatosClient platosClient = new PlatosServ.PlatosClient();

                platosClient.EliminarPlato(2014);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        [TestMethod]
        public void TestListar()
        {
            try
            {
                PlatosServ.PlatosClient platosClient = new PlatosServ.PlatosClient();

                platosClient.ObtenerPlatos();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        [TestMethod]
        public void TestBusquedaNoEncontrada()
        {
            try
            {
                PlatosServ.PlatosClient platosClient = new PlatosServ.PlatosClient();
                platosClient.ObtenerPlatobyName("Causa Rellena");
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        

    }
}
