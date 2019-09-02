using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
namespace TestServiceWCF
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCrear()
        {
            PlatosServ.PlatosClient platosClient = new PlatosServ.PlatosClient();

            PlatosServ.Plato plato= platosClient.RegistrarPlato(
                new PlatosServ.Plato
                {
                    Id_plato = 9999,
                    Descripcion = "Arroz  Chaufa",
                    Precio = (decimal)17.50,
                    Url = "https://developersonline2019.net/resources/21.png"
                }
            );

            Assert.AreEqual(9999, plato.Id_plato);
            Assert.AreEqual("Arroz  Chaufa", plato.Descripcion);
            Assert.AreEqual(17.50, plato.Precio);
            Assert.AreEqual("https://developersonline2019.net/resources/21.png", plato.Url);

        }
        [TestMethod]
        public void TestModificar()
        {
            PlatosServ.PlatosClient platosClient = new PlatosServ.PlatosClient();

            PlatosServ.Plato plato = platosClient.RegistrarPlato(
                new PlatosServ.Plato
                {
                    Id_plato = 9999,
                    Descripcion = "Arroz Blanco",
                    Precio = (decimal)17.50,
                    Url = "https://developersonline2019.net/resources/21.png"
                }
            );

            Assert.AreEqual(9999, plato.Id_plato);
            Assert.AreEqual("Arroz Blanco", plato.Descripcion);
            Assert.AreEqual(20.50, plato.Precio);
            Assert.AreEqual("https://developersonline2019.net/resources/21.png", plato.Url);

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
                Assert.AreEqual("Error al ingresar el registro", err.Reason.ToString());
                Assert.AreEqual(err.Detail.codigo, "101");
                Assert.AreEqual(err.Detail.descripcion, "El plato a registrar, ya existe.");
                throw;
            }
            
        }
        [TestMethod]
        public void TestEliminarRegistro()
        {
            PlatosServ.PlatosClient platosClient = new PlatosServ.PlatosClient();

            platosClient.EliminarPlato(9999);
        }
        [TestMethod]
        public void TestListar()
        {
            PlatosServ.PlatosClient platosClient = new PlatosServ.PlatosClient();

            platosClient.ObtenerPlatos();
        }
        [TestMethod]
        public void TestBusquedaNoEncontrada()
        {
            PlatosServ.PlatosClient platosClient = new PlatosServ.PlatosClient();
            platosClient.ObtenerPlatobyName("Causa Rellena");
        }
        

    }
}
