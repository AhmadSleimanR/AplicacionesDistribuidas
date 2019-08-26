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
                SqlCommand cmd = new SqlCommand("insert into CLIENTES(username, userpass, nombre, apellidos, email, direccion, dni)" +
                    "values(@Username,@Userpass,@Nombre,@Apellidos,@Email,@Direccion,@Dni)", con);
                cmd.Parameters.AddWithValue("@Username", cliente.Username);
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

        public Cliente FindCliente(int clientes_id)
        {
            Cliente cliente = new Cliente();
            try
            {
                SqlConnection con = new SqlConnection("Server=.;Database=RestauranteBD;User Id=sa;Password = 12345;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from CLIENTES where clientes_id=@Clientes_id", con);
                cmd.Parameters.AddWithValue("@Clientes_id", clientes_id);
                SqlDataReader dtr = cmd.ExecuteReader();
                dtr.Read();
                cliente.Clientes_id = int.Parse(dtr["clientes_id"].ToString());
                cliente.Username = dtr["username"].ToString();
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
                SqlCommand cmd = new SqlCommand("Update CLIENTES set username = @Username, userpass = @Userpass, nombre = @nombre, apellidos = @apellidos, "+
                        "email=@email,direccion=@direccion,dni=@dni where clientes_id=@Clientes_id", con);
                cmd.Parameters.AddWithValue("@Clientes_id", cliente.Clientes_id);
                cmd.Parameters.AddWithValue("@Username", cliente.Username);
                cmd.Parameters.AddWithValue("@Userpass", cliente.Userpass);
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

        public string Delete(int clientes_id)
        {
            String msg;
            try {
                SqlConnection con = new SqlConnection("Server=.;Database=RestauranteBD;User Id=sa;Password = 12345;");
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE from where clientes_id=@Clientes_id", con);
                cmd.Parameters.AddWithValue("@Clientes_id", clientes_id);
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
    }
}
