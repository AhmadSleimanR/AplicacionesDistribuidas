using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PedidoServiceWCF_AG.Dominio;

namespace PedidoServiceWCF_AG.Persistencia
{
    public class PedidoDAO
    {
        private string sConexion = "Server=tcp:angeldev.database.windows.net,1433;Initial Catalog=angeldev;Persist Security Info=False;User ID=angel;Password=defqon1@A;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public Pedido Crear(Pedido pedidoCrear)
        {
            Pedido pedidoCreado = null;
            string sql = "INSERT INTO Pedido VALUES(@dni,@fecha,@subtotal,@igv,@total)";
            SqlConnection sqlConnection = new SqlConnection(sConexion);
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection)) {
                sqlCommand.Parameters.Add(new SqlParameter("@dni", pedidoCrear.Dni));
                sqlCommand.Parameters.Add(new SqlParameter("@fecha", pedidoCrear.Fecha));
                sqlCommand.Parameters.Add(new SqlParameter("@subtotal", pedidoCrear.SubTotal));
                sqlCommand.Parameters.Add(new SqlParameter("@igv", pedidoCrear.Igv));
                sqlCommand.Parameters.Add(new SqlParameter("@total", pedidoCrear.Total));
                sqlCommand.ExecuteNonQuery();
            }
            pedidoCreado = Obtener(pedidoCrear.Dni);
            sqlConnection.Close();
            return pedidoCreado;
        }

        public Pedido Obtener(string dni)
        {
            Pedido pedidoEncontrado = null;
            string sql = "SELECT * FROM Pedido WHERE Dni = @dni";
            SqlConnection sqlConnection = new SqlConnection(sConexion);
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection)) {
                sqlCommand.Parameters.Add(new SqlParameter("@dni", dni));
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read()) {
                    pedidoEncontrado = new Pedido();
                    pedidoEncontrado.Dni = sqlDataReader.GetString(0);
                    pedidoEncontrado.Fecha = sqlDataReader.GetDateTime(1);
                    pedidoEncontrado.SubTotal = Convert.ToDouble(sqlDataReader.GetDecimal(2));
                    pedidoEncontrado.Igv = Convert.ToDouble(sqlDataReader.GetDecimal(3));
                    pedidoEncontrado.Total = Convert.ToDouble(sqlDataReader.GetDecimal(4));
                //};
                }
                sqlConnection.Close();
                return pedidoEncontrado;
            }
        }

        public Pedido Modificar(Pedido pedidoMoficar)
        {
            Pedido pedidoModificado = null;
            string sql = "UPDATE Pedido SET fecha = @fecha, subtotal = @subtotal,igv = @igv,total =@total WHERE dni = @dni";
            SqlConnection sqlConnection = new SqlConnection(sConexion);
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.Parameters.Add(new SqlParameter("@fecha", pedidoMoficar.Fecha));
                sqlCommand.Parameters.Add(new SqlParameter("@subtotal", pedidoMoficar.SubTotal));
                sqlCommand.Parameters.Add(new SqlParameter("@igv", pedidoMoficar.Igv));
                sqlCommand.Parameters.Add(new SqlParameter("@total", pedidoMoficar.Total));
                sqlCommand.Parameters.Add(new SqlParameter("@dni", pedidoMoficar.Dni));
                sqlCommand.ExecuteNonQuery();
            }
            pedidoModificado = Obtener(pedidoMoficar.Dni);
            sqlConnection.Close();
            return pedidoModificado;
        }

        public void Eliminar(string dni)
        {

        }

        public List<Pedido> Listar()
        {
            List<Pedido> pedidosEncontrados = new List<Pedido>();
            Pedido pedidoEncontrado = null;
            string sql = "SELECT * FROM Pedido";
            SqlConnection sqlConnection = new SqlConnection(sConexion);            
            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection)) {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while(sqlDataReader.Read()) {
                    pedidoEncontrado = new Pedido();
                    pedidoEncontrado.Dni = sqlDataReader.GetString(0);
                    pedidoEncontrado.Fecha = sqlDataReader.GetDateTime(1);
                    pedidoEncontrado.SubTotal = Convert.ToDouble(sqlDataReader.GetDecimal(2));
                    pedidoEncontrado.Igv = Convert.ToDouble(sqlDataReader.GetDecimal(3));
                    pedidoEncontrado.Total = Convert.ToDouble(sqlDataReader.GetDecimal(4));
                    pedidosEncontrados.Add(pedidoEncontrado);
                }
                sqlConnection.Close();
                return pedidosEncontrados;
            }
        }
    }
}