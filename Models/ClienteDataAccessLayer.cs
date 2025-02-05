using System.Collections.Generic;
using System.Data.SqlClient;
using Test.Data;

namespace Test.Models
{
    public class ClienteDataAccessLayer
    {
        string conneccionString = "Server=ANTONI;Database=DBProdcutos;User ID=sa;Password=adminadmin123;TrustServerCertificate=true;MultipleActiveResultSets=true";

        public List<Cliente> getAllCliente()
        {
            List<Cliente> listaCliente = new List<Cliente>();

            using (SqlConnection con = new SqlConnection(conneccionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_SelectAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        Codigo = Convert.ToInt32(rdr["codigo"]),
                        Cedula = rdr["cedula"].ToString(),
                        Apellido = rdr["apellido"].ToString(),
                        Nombre = rdr["nombre"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(rdr["fecha_nacimiento"]),
                        Email = rdr["email"].ToString(),
                        Telefono = rdr["telefono"].ToString(),
                        Direccion = rdr["direccion"].ToString(),
                        Estado = Convert.ToBoolean(rdr["estado"])
                   };
                    listaCliente.Add(cliente);
                }
            }
            return listaCliente;
        }
    }

   
}
