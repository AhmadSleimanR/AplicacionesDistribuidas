using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApp.Errores;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RegistrarController : Controller
    {
        // GET: Registrar
        public ActionResult Index()
        {


            return View();
        }

        [HttpPost ]
        public JsonResult Store(Cliente cliente )
        {

   
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(cliente);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.
            Create("http://localhost:2153/Clientes.svc/Clientes");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);

            Cliente paymentCreado=null;
            try
            {

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
  StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
              paymentCreado = js.Deserialize<Cliente >(tramaJson);

            }
          
            catch (WebException ex)
            {
                var error = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();

                ErrorException err = js.Deserialize<ErrorException>(error);

                return Json(err);

            }



            return Json(paymentCreado);

        }

        public JsonResult Verificar(Cliente cliente)
        {


            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(cliente);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.
            Create("http://localhost:2153/Clientes.svc/Verificar");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);

            Cliente paymentCreado = null;
            try
            {

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string tramaJson = reader.ReadToEnd();
                paymentCreado = js.Deserialize<Cliente>(tramaJson);

            }

            catch (WebException ex)
            {
                var error = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();

                ErrorException err = js.Deserialize<ErrorException>(error);

                return Json(err);

            }



            return Json(paymentCreado);

        }
    }
}