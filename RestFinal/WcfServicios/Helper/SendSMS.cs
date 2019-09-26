using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WcfServicios.Helper
{
    public class SendSMS
    {

        public void ENVIAR(string numero, string mensaje)
        {

            //Se fija la URL sobre la que enviar la petici´on POST
            HttpWebRequest loHttp =
            (HttpWebRequest)WebRequest.Create("http://www.altiria.net/api/http");
            // Compone el mensaje a enviar
            // 33
            //Especificaciones de la Interfaz HTTP para env´ıo de SMS
            // XX, YY y ZZ se corresponden con los valores de identificaci´on del usuario en el sistema.
            string lcPostData = $"cmd=sendsms&domainId=test&login=jose.zapata@celeritech.biz&passwd=ujtsb2r9&dest={numero}&msg={mensaje}";
            //es posible utilizar el remitente en Am´erica pero s´ı en Espa~na y Europa
            //Descomentar la l´ınea solo si se cuenta con un remitente autorizado por Altiria
            //cmd=cmd + "&senderId=remitente";
            // Se codifica en utf-8
            byte[] lbPostBuffer = System.Text.Encoding.GetEncoding("utf-8").GetBytes(lcPostData);
            loHttp.Method = "POST";
            loHttp.ContentType = "application/x-www-form-urlencoded";
            loHttp.ContentLength = lbPostBuffer.Length;
            //Fijamos tiempo de espera de respuesta = 60 seg
            loHttp.Timeout = 60000;
            String error = "";
            String response = "";
            // Env´ıa la peticion
            try
            {
                Stream loPostData = loHttp.GetRequestStream();
                loPostData.Write(lbPostBuffer, 0, lbPostBuffer.Length);
                loPostData.Close();
                // Prepara el objeto para obtener la respuesta
                HttpWebResponse loWebResponse = (HttpWebResponse)loHttp.GetResponse();
                // La respuesta vendr´ıa codificada en utf-8
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader loResponseStream =
                new StreamReader(loWebResponse.GetResponseStream(), enc);
                // Conseguimos la respuesta en una cadena de texto
                response = loResponseStream.ReadToEnd();
                loWebResponse.Close();
                loResponseStream.Close();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ConnectFailure)
                    error = "Error en la conexi´on";
                else if (e.Status == WebExceptionStatus.Timeout)
                    error = "Error TimeOut";
                else
                    error = e.Message;
            }
            finally
            {
                if (error != "")
                    Console.WriteLine(error);
                else
                    Console.WriteLine(response);
            }
        }

    }
}