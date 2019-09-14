using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCF_REST.Dominio;

namespace WCF_REST.Dominio
{
    public class PlatoDAO
    {
        private string CadenaConexionBD = "Data Source=192.168.226.130;Initial Catalog=DB_RESTAURANTE;Persist Security Info=True;User ID=user_logon;Password=@pass2019";
        public Plato RegistrarPlato(Plato plato)
        {
            string sql = "INSERT INTO plato(no_plato, mt_precio, url_img) VALUES (@descripcion,@precio,@url)";
            Plato NuevoPlato = null;
            using (SqlConnection conexionBD = new SqlConnection(CadenaConexionBD))
            {
                conexionBD.Open();
                using (SqlCommand command = new SqlCommand(sql, conexionBD))
                {
                    command.Parameters.Add(new SqlParameter("@descripcion", plato.Descripcion));
                    command.Parameters.Add(new SqlParameter("@precio", plato.Precio));
                    command.Parameters.Add(new SqlParameter("@url", plato.Url));
                    command.ExecuteNonQuery();
                }
            }
            NuevoPlato = ObtenerPlatoporNombre(plato.Descripcion);
            return NuevoPlato;
        }
        public Plato ObtenerPlatoporId(int id_plato)
        {
            Plato platoEncontrado = null;
            string sql = "SELECT * FROM plato WHERE nid_plato = @id_plato";
            using (SqlConnection conexionBD = new SqlConnection(CadenaConexionBD))
            {
                conexionBD.Open();
                using (SqlCommand command = new SqlCommand(sql, conexionBD))
                {
                    command.Parameters.Add(new SqlParameter("@id_plato", id_plato));
                    using (SqlDataReader DataResult = command.ExecuteReader())
                    {
                        if (DataResult.Read())
                        {
                            platoEncontrado = new Plato()
                            {
                                Id_plato = (int)DataResult["nid_plato"],
                                Descripcion = (string)DataResult["no_plato"],
                                Url = (string)DataResult["url_img"],
                                Precio = (decimal)DataResult["mt_precio"]
                            };
                        }
                    }
                }
            }

            return platoEncontrado;
        }
        public Plato ObtenerPlatoporNombre(string nombre_plato)
        {
            Plato platoEncontrado = null;
            string sql = "SELECT * FROM plato WHERE no_plato = @descripcion";
            using (SqlConnection conexionBD = new SqlConnection(CadenaConexionBD))
            {
                conexionBD.Open();
                using (SqlCommand command = new SqlCommand(sql, conexionBD))
                {
                    command.Parameters.Add(new SqlParameter("@descripcion", nombre_plato));
                    using (SqlDataReader DataResult = command.ExecuteReader())
                    {
                        if (DataResult.Read())
                        {
                            platoEncontrado = new Plato()
                            {
                                Id_plato = (int)DataResult["nid_plato"],
                                Descripcion = (string)DataResult["no_plato"],
                                Url = (string)DataResult["url_img"],
                                Precio = (decimal)DataResult["mt_precio"]
                            };
                        }
                    }
                }
            }

            return platoEncontrado;
        }
        public List<Plato> ObtenerPlatos()
        {
            List<Plato> ListaPlatos = new List<Plato>();
            Plato platoEncontrado = null;
            string sql = "SELECT * FROM plato";
            using (SqlConnection conexionBD = new SqlConnection(CadenaConexionBD))
            {
                conexionBD.Open();
                using (SqlCommand command = new SqlCommand(sql, conexionBD))
                {
                    using (SqlDataReader DataResult = command.ExecuteReader())
                    {
                        while (DataResult.Read())
                        {
                            platoEncontrado = new Plato()
                            {
                                Id_plato = (int)DataResult["nid_plato"],
                                Descripcion = (string)DataResult["no_plato"],
                                Url = (string)DataResult["url_img"],
                                Precio = (decimal)DataResult["mt_precio"]
                            };
                            ListaPlatos.Add(platoEncontrado);
                        }
                    }
                }
            }
            return ListaPlatos;
        }
        public Plato ModificarPlato(Plato plato)
        {
            string sql = "UPDATE plato set no_plato=@descripcion, mt_precio = @precio, url_img=@url WHERE nid_plato = @nid_plato";
            Plato PlatoModificado = null;
            using (SqlConnection conexionBD = new SqlConnection(CadenaConexionBD))
            {
                conexionBD.Open();
                using (SqlCommand command = new SqlCommand(sql, conexionBD))
                {
                    command.Parameters.Add(new SqlParameter("@nid_plato", plato.Id_plato));
                    command.Parameters.Add(new SqlParameter("@descripcion", plato.Descripcion));
                    command.Parameters.Add(new SqlParameter("@url", plato.Url));
                    command.Parameters.Add(new SqlParameter("@precio", plato.Precio));
                    command.ExecuteNonQuery();
                }
            }
            PlatoModificado = ObtenerPlatoporId(plato.Id_plato);
            return PlatoModificado;
        }
        public void EliminarPlato(int id_plato)
        {
            string sql = "DELETE FROM plato WHERE nid_plato = @nid_plato";

            using (SqlConnection conexionBD = new SqlConnection(CadenaConexionBD))
            {
                conexionBD.Open();
                using (SqlCommand command = new SqlCommand(sql, conexionBD))
                {
                    command.Parameters.Add(new SqlParameter("@nid_plato", id_plato));
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}