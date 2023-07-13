using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Integrando_Apis_con_ADO.NET.Models;

namespace Integrando_Apis_con_ADO.NET.Repository
{
    public class ADO_Ventas
    {

        static string connectionString = "Server=localhost;Database=SistemaGestion;Trusted_Connection=True";

        public static List<Venta> ObtenerVentas()
        {
            List<Venta> ventas = new List<Venta>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, comentarios FROM Venta";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Venta venta = new Venta();
                    venta.id = Convert.ToInt32(reader["id"]);
                    venta.Comentarios = (string)reader["comentarios"];

                    ventas.Add(venta);
                }

                reader.Close();
            }

            return ventas;
        }

        public static long CargarVenta(Venta venta)
        {
            long idVenta = 0;

            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [SistemaGestion].[dbo].[Venta] (Comentarios) " +
                                        "VALUES (@comentarios) " +
                                        "SELECT @@IDENTITY";

                var parameterComentarios = new SqlParameter("comentarios", SqlDbType.VarChar);
                parameterComentarios.Value = venta.Comentarios;

                Connection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(query, Connection))
                {
                    sqlCommand.Parameters.Add(parameterComentarios);
                    idVenta = Convert.ToInt64(sqlCommand.ExecuteScalar());
                }
                Connection.Close();
            }
            return idVenta;
        }



    }
}