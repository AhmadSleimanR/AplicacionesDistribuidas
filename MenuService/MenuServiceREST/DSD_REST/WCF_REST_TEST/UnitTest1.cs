using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WCF_REST_TEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCrear()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Plato platoNuevo = new Plato()
            {
                Descripcion = "Lomo Saltado de Casa",
                Precio = (decimal)30.50,
                Url = "https://developersonline2019.net/resources/21.png"
            };
            string data = js.Serialize(platoNuevo);
            byte[] dataByte = Encoding.UTF8.GetBytes(data);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5436/Platos.svc/Platos");

            webRequest.Method = "POST";
            webRequest.ContentLength = dataByte.Length;
            webRequest.ContentType = "application/json";

            var requestStream = webRequest.GetRequestStream();

            requestStream.Write(dataByte, 0, dataByte.Length);

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());

            string resultJSON = streamReader.ReadToEnd();

            Plato platoCreado = js.Deserialize<Plato>(resultJSON);

            Assert.AreEqual(platoNuevo.Descripcion, platoCreado.Descripcion);
            Assert.AreEqual(platoNuevo.Precio, platoCreado.Precio);
            Assert.AreEqual(platoNuevo.Url, platoCreado.Url);
        }
        [TestMethod]
        public void TestCrearRepetido()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Plato platoNuevo = new Plato()
            {
                Descripcion = "Lomo Saltado",
                Precio = (decimal)20.50,
                Url = "https://developersonline2019.net/resources/21.png"
            };
            string data = js.Serialize(platoNuevo);
            byte[] dataByte = Encoding.UTF8.GetBytes(data);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5436/Platos.svc/Platos");

            webRequest.Method = "POST";
            webRequest.ContentLength = dataByte.Length;
            webRequest.ContentType = "application/json";

            var requestStream = webRequest.GetRequestStream();

            requestStream.Write(dataByte, 0, dataByte.Length);
            HttpWebResponse webResponse = null;

            try
            {
                webResponse = (HttpWebResponse)webRequest.GetResponse();

                StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());

                string resultJSON = streamReader.ReadToEnd();

                Plato platoCreado = js.Deserialize<Plato>(resultJSON);

                Assert.AreEqual(platoNuevo.Descripcion, platoCreado.Descripcion);
                Assert.AreEqual(platoNuevo.Precio, platoCreado.Precio);
                Assert.AreEqual(platoNuevo.Url, platoCreado.Url);
            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string tramaJSON = reader.ReadToEnd();

                ManejoException foundError = js.Deserialize<ManejoException>(tramaJSON);

                Assert.AreEqual(HttpStatusCode.Conflict, code);
                Assert.AreEqual("El plato que desea registrar ya existe", foundError.descripcion);
            }

        }

        [TestMethod]
        public void TestObtenerPlato()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5436/Platos.svc/Platos/2015");

            webRequest.Method = "GET";

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());

            string resultJSON = streamReader.ReadToEnd();

            Plato platoObtenido = js.Deserialize<Plato>(resultJSON);

            Assert.AreEqual("Arroz Chaufa", platoObtenido.Descripcion);
            Assert.AreEqual((decimal)20.5, platoObtenido.Precio);
            Assert.AreEqual("https://developersonline2019.net/resources/21.png", platoObtenido.Url);

        }

        [TestMethod]
        public void TestModificarPlato()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Plato platoNuevo = new Plato()
            {
                Id_plato = 2026,
                Descripcion = "Lomo Saltado Carta",
                Precio = (decimal)24.50,
                Url = "https://developersonline2019.net/resources/21.png"
            };
            string data = js.Serialize(platoNuevo);
            byte[] dataByte = Encoding.UTF8.GetBytes(data);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5436/Platos.svc/Platos");

            webRequest.Method = "PUT";
            webRequest.ContentLength = dataByte.Length;
            webRequest.ContentType = "application/json";

            var requestStream = webRequest.GetRequestStream();

            requestStream.Write(dataByte, 0, dataByte.Length);

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());

            string resultJSON = streamReader.ReadToEnd();

            Plato platoCreado = js.Deserialize<Plato>(resultJSON);

            Assert.AreEqual(platoNuevo.Descripcion, platoCreado.Descripcion);
            Assert.AreEqual(platoNuevo.Precio, platoCreado.Precio);
            Assert.AreEqual(platoNuevo.Url, platoCreado.Url);
        }
        [TestMethod]
        public void TestEliminarPlato()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5436/Platos.svc/Platos/2026");

            webRequest.Method = "DELETE";

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            JavaScriptSerializer js = new JavaScriptSerializer();

            HttpWebRequest webRequestND = (HttpWebRequest)WebRequest.Create("http://localhost:5436/Platos.svc/Platos/2026");

            webRequestND.Method = "GET";

            HttpWebResponse webResponseND = (HttpWebResponse)webRequestND.GetResponse();

            StreamReader streamReader = new StreamReader(webResponseND.GetResponseStream());

            string resultJSON = streamReader.ReadToEnd();

            Plato platoObtenido = js.Deserialize<Plato>(resultJSON);

            Assert.IsNull(platoObtenido);
        }

        [TestMethod]
        public void TestObtenerPlatos()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5436/Platos.svc/Platos");

            webRequest.Method = "GET";

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());

            string resultJSON = streamReader.ReadToEnd();

           List<Plato> platosObtenidos = js.Deserialize<List<Plato>>(resultJSON);

            Assert.AreEqual(2, platosObtenidos.Count);
        }
    }
}
