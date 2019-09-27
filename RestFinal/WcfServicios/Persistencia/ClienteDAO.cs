using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfServicios.Dominio;
using WcfServicios.Helper;

namespace WcfServicios.Persistencia
{
    public class ClienteDAO
    {

        private string CadenaConexion = "Data Source=DESKTOP-EJM18E6;Initial Catalog=Restaurant;User ID=sa;Password=12345";
        public Cliente Crear(Cliente ClienteACrear)
        {
             Cliente ClienteCreado = null;
            string sql = "INSERT INTO CLIENTES   (username ,userpass  ,nombre,apellidos ,email ,direccion  ,dni ,celular,codigo)   VALUES (@username ,@userpass  ,@nombre,@apellidos ,@email ,@direccion  ,@dni ,@celular,@codigo)";
            using (SqlConnection conex = new SqlConnection(CadenaConexion))
            {
                conex.Open();
                using (SqlCommand comando = new SqlCommand(sql, conex))
                {
                    try
                    {
                        comando.Parameters.Add(new SqlParameter("@username", ClienteACrear.UserName));
                        comando.Parameters.Add(new SqlParameter("@userpass", ClienteACrear.UserPass));
                        comando.Parameters.Add(new SqlParameter("@nombre", ClienteACrear.Nombres));
                        comando.Parameters.Add(new SqlParameter("@apellidos", ClienteACrear.Apellidos));
                        comando.Parameters.Add(new SqlParameter("@email", ClienteACrear.Email));
                        comando.Parameters.Add(new SqlParameter("@direccion", ClienteACrear.Direccion));
                        comando.Parameters.Add(new SqlParameter("@dni", ClienteACrear.Dni));
                        comando.Parameters.Add(new SqlParameter("@celular", ClienteACrear.Telefono));
                        comando.Parameters.Add(new SqlParameter("@codigo", ClienteACrear.Codigo ));

                        //comando.ExecuteNonQuery();
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);   

                    }
                   

                }
            }
            
            string mensaje = $"{ClienteACrear.Nombres } tu codigo de verificacion es {ClienteACrear.Codigo } ";
            new SendSMS().ENVIAR(ClienteACrear.Telefono, mensaje);

            ClienteCreado = Obtener(ClienteACrear.Dni );
            return ClienteCreado;
        }
        public Cliente Obtener(string dni)
        {
            Cliente ClienteEncontrado = null;
            string sql = "SELECT * FROM CLIENTES WHERE dni = @dni";
            using (SqlConnection conex = new SqlConnection(CadenaConexion))
            {
                conex.Open();
                using (SqlCommand comando = new SqlCommand(sql, conex))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", dni));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            ClienteEncontrado = new Cliente()
                            {
 

                                UserName = resultado["username"].ToString(),
                                UserPass = resultado["userpass"].ToString (),
                                Nombres = resultado["nombre"].ToString(),
                                Apellidos = resultado["apellidos"].ToString(),
                                Email = resultado["email"].ToString(),
                                Direccion = resultado["direccion"].ToString(),
                                Dni = resultado["dni"].ToString(),
                                Telefono = resultado["celular"].ToString()
 
                            };
                        }
                    }
                }



                return ClienteEncontrado;
            }
        }
        public Cliente VerificarCodigo(string dni,string codigo)
        {
            Cliente ClienteEncontrado = null;
            string sql = "SELECT * FROM CLIENTES WHERE dni = @dni and codigo=@codigo";
            using (SqlConnection conex = new SqlConnection(CadenaConexion))
            {
                conex.Open();
                using (SqlCommand comando = new SqlCommand(sql, conex))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", dni));
                    comando.Parameters.Add(new SqlParameter("@codigo", codigo));

                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            ClienteEncontrado = new Cliente()
                            {


                                UserName = resultado["username"].ToString(),
                                UserPass = resultado["userpass"].ToString(),
                                Nombres = resultado["nombre"].ToString(),
                                Apellidos = resultado["apellidos"].ToString(),
                                Email = resultado["email"].ToString(),
                                Direccion = resultado["direccion"].ToString(),
                                Dni = resultado["dni"].ToString(),
                                Telefono = resultado["celular"].ToString()

                            };
                        }
                    }
                }



                return ClienteEncontrado;
            }
        }


        public Cliente VerifcarEmail(string email)
        {
            Cliente ClienteEncontrado = null;
            string sql = "SELECT * FROM CLIENTES WHERE email = @email";
            using (SqlConnection conex = new SqlConnection(CadenaConexion))
            {
                conex.Open();
                using (SqlCommand comando = new SqlCommand(sql, conex))
                {
                    comando.Parameters.Add(new SqlParameter("@email", email));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            ClienteEncontrado = new Cliente()
                            {
                                UserName = resultado["username"].ToString(),
                                UserPass = resultado["userpass"].ToString(),
                                Nombres = resultado["nombre"].ToString(),
                                Apellidos = resultado["apellidos"].ToString(),
                                Email = resultado["email"].ToString(),
                                Direccion = resultado["direccion"].ToString(),
                                Dni = resultado["dni"].ToString(),
                                Telefono = resultado["celular"].ToString()
                            };
                        }
                    }
                }
                return ClienteEncontrado;
            }
        }


        public Cliente Modificar(Cliente ClienteAModificar)
        {
            Cliente ClienteModificado = null;
            string sql = "UPDATE CLIENTES SET username = @username, userpass = @userpass ,nombre = @nombre ,apellidos = @apellidos ,email = @email ,direccion = @direccion ,dni = @dni,celular = @celular WHERE dni = @dni ";
            using (SqlConnection conex = new SqlConnection(CadenaConexion))
            {
                conex.Open();
                using (SqlCommand comando = new SqlCommand(sql, conex))
                {
                    comando.Parameters.Add(new SqlParameter("@username", ClienteAModificar.UserName));
                    comando.Parameters.Add(new SqlParameter("@userpass", ClienteAModificar.UserPass));
                    comando.Parameters.Add(new SqlParameter("@nombre", ClienteAModificar.Nombres));
                    comando.Parameters.Add(new SqlParameter("@apellidos", ClienteAModificar.Apellidos));
                    comando.Parameters.Add(new SqlParameter("@email", ClienteAModificar.Email));
                    comando.Parameters.Add(new SqlParameter("@direccion", ClienteAModificar.Direccion));
                    comando.Parameters.Add(new SqlParameter("@dni", ClienteAModificar.Dni));
                    comando.Parameters.Add(new SqlParameter("@celular", ClienteAModificar.Telefono));
                    comando.ExecuteNonQuery();
                }
            }
            ClienteModificado = Obtener(ClienteAModificar.Dni);
            return ClienteModificado;
        }
        public void Eliminar(int dni)
        {
            string sql = "DELETE FROM CLIENTES WHERE dni = @dni";
            using (SqlConnection conex = new SqlConnection(CadenaConexion))
            {
                conex.Open();
                using (SqlCommand comando = new SqlCommand(sql, conex))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", dni));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Cliente> Listar()
        {
            List<Cliente> ClientesEncontrados = new List<Cliente>();
            Cliente ClienteEncontrado = null;
            string sql = "SELECT * FROM CLIENTES";
            using (SqlConnection conex = new SqlConnection(CadenaConexion))
            {
                conex.Open();
                using (SqlCommand comando = new SqlCommand(sql, conex))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            ClienteEncontrado = new Cliente()
                            {
                                UserName = resultado["username"].ToString(),
                                UserPass = resultado["userpass"].ToString(),
                                Nombres = resultado["nombre"].ToString(),
                                Apellidos = resultado["apellidos"].ToString(),
                                Email = resultado["email"].ToString(),
                                Direccion = resultado["direccion"].ToString(),
                                Dni = resultado["dni"].ToString(),
                                Telefono = resultado["celular"].ToString()
                            };
                            ClientesEncontrados.Add(ClienteEncontrado);
                        }
                    }
                }
            }
            return ClientesEncontrados;
        }

        public Cliente Verificado(string dni)
        {
            Cliente ClienteModificado = null;
            string sql = "UPDATE CLIENTES SET verificado=1 , codigo='' WHERE dni = @dni ";
            using (SqlConnection conex = new SqlConnection(CadenaConexion))
            {
                conex.Open();
                using (SqlCommand comando = new SqlCommand(sql, conex))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", dni));
                    ;
                    comando.ExecuteNonQuery();
                }
            }
            ClienteModificado = Obtener(dni);
            return ClienteModificado;
        }

    }
}