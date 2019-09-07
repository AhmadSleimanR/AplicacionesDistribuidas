using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClienteService
{
   public class ClienteService : IClienteService
    {

        public String Insert(Cliente cliente)
        {
            try
            {
                String msg;
                SqlConnection con = new SqlConnection("Server=.;Database=RestauranteBD;User Id=sa;Password = 12345;");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into CLIENTES( userpass, nombre, apellidos, email, direccion, dni)" +
                    "values(@Userpass,@Nombre,@Apellidos,@Email,@Direccion,@Dni)", con);
                 cmd.Parameters.AddWithValue("@Userpass", cliente.Userpass);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@Dni", cliente.Dni);
                int operation = cmd.ExecuteNonQuery();
                con.Close();
                if (operation == 1) {
                    msg = "Operacion realizada con exito!";
                }
                else
                {
                    msg = "La operacion no se pudo realizar.";
                }
                return msg;
            }
            catch (Exception e) {
                Console.WriteLine("Error: "+e);
                return "Error"+e;
            }
        }

        public Cliente FindCliente(int dni)
        {
            Cliente cliente = new Cliente();
            try
            {
                SqlConnection con = new SqlConnection("Server=.;Database=RestauranteBD;User Id=sa;Password = 12345;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from CLIENTES where dni=@dni", con);
                cmd.Parameters.AddWithValue("@dni", dni);
                SqlDataReader dtr = cmd.ExecuteReader();
                dtr.Read();
                 cliente.Userpass = dtr["userpass"].ToString();
                cliente.Nombre = dtr["nombre"].ToString();
                cliente.Apellidos = dtr["apellidos"].ToString();
                cliente.Email = dtr["email"].ToString();
                cliente.Direccion = dtr["direccion"].ToString();
                cliente.Dni = dtr["dni"].ToString();
                con.Close();
                return cliente;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return null;
            }
        }

        public string Update(Cliente cliente)
        {
            string msg;
            try
            {
                SqlConnection con = new SqlConnection("Server=.;Database=RestauranteBD;User Id=sa;Password = 12345;");
                con.Open();
                SqlCommand cmd = new SqlCommand("Update CLIENTES set   nombre = @nombre, apellidos = @apellidos, "+
                        "email=@email,direccion=@direccion where dni=@dni ", con);
                 cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@Dni", cliente.Dni);
                int operation = cmd.ExecuteNonQuery();
                con.Close();
                if (operation == 1)
                {
                    msg = "Operacion realizada con exito!";
                }
                else
                {
                    msg = "La operacion no se pudo realizar.";
                }
                return msg;
                }
           catch (Exception e)
           {
               Console.WriteLine("Error: " + e);
               return "Error" + e;
           }
        }

        public string Delete(int dni)
        {
            String msg;
            try {
                SqlConnection con = new SqlConnection("Server=.;Database=RestauranteBD;User Id=sa;Password = 12345;");
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE from CLIENTES where dni=@dni", con);
                cmd.Parameters.AddWithValue("@dni", dni);
                int operation = cmd.ExecuteNonQuery();
                con.Close();
                if (operation == 1)
                {
                    msg = "Operacion realizada con exito!";
                }
                else
                {
                    msg = "La operacion no se pudo realizar.";
                }
                return msg;
            }catch(Exception e)
            {
                Console.WriteLine("Error: " + e);
                return null;
            }
        }

        public List<Cliente> ListarClientes() 
        {

            List<Cliente> Clientes = new List<Cliente>();
            Cliente cliente = null;
            try
            {
                SqlConnection con = new SqlConnection("Server=.;Database=RestauranteBD;User Id=sa;Password = 12345;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from CLIENTES  ", con);
                 SqlDataReader dtr = cmd.ExecuteReader();
                while (dtr.Read()) {
                      cliente = new Cliente();
                    cliente.Userpass = dtr["userpass"].ToString();
                    cliente.Nombre = dtr["nombre"].ToString();
                    cliente.Apellidos = dtr["apellidos"].ToString();
                    cliente.Email = dtr["email"].ToString();
                    cliente.Direccion = dtr["direccion"].ToString();
                    cliente.Dni = dtr["dni"].ToString();

                    Clientes.Add(cliente);

                };


               


                con.Close();
                return Clientes;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return null;
            }
        }
    }
}
