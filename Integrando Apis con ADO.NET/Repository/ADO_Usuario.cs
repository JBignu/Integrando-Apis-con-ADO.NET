using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Integrando_Apis_con_ADO.NET.Models;

namespace Integrando_Apis_con_ADO.NET.Repository
{
    public class ADO_Usuario
    {
        static string connectionString = "Server=localhost;Database=SistemaGestion;Trusted_Connection=True";

        public static List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, nombre, apellido, nombreUsuario, contrasena, mail FROM Usuario";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.id = Convert.ToInt32(reader["id"]);
                    usuario.nombre = (string)reader["nombre"];
                    usuario.apellido = (string)reader["apellido"];
                    usuario.nombreUsuario = (string)reader["nombreUsuario"];
                    usuario.contrasena = (string)reader["contrasena"];
                    usuario.mail = (string)reader["mail"];

                    usuarios.Add(usuario);
                }

                reader.Close();
            }

            return usuarios;
        }

        public static bool ModificarUsuario(Usuario usuario)
        {
            bool resultado = false;
            int rowsAffected = 0;


            if (usuario.id <= 0)
            {
                return false;
            }

            if (String.IsNullOrEmpty(usuario.nombre) ||
                String.IsNullOrEmpty(usuario.apellido) ||
                String.IsNullOrEmpty(usuario.nombreUsuario) ||
                String.IsNullOrEmpty(usuario.contrasena) ||
                String.IsNullOrEmpty(usuario.mail))
            {
                return false;
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = "UPDATE [SistemaGestion].[dbo].[Usuario] " +
                                        "SET Nombre = @nombre, " +
                                            "Apellido = @apellido, " +
                                            "NombreUsuario = @nombreUsuario, " +
                                            "Contraseña = @contraseña, " +
                                            "Mail = @mail " +
                                            "WHERE Id = @id";

                var parameterNombre = new SqlParameter("nombre", SqlDbType.VarChar);
                parameterNombre.Value = usuario.nombre;

                var parameterApellido = new SqlParameter("apellido", SqlDbType.VarChar);
                parameterApellido.Value = usuario.apellido;

                var parameterNombreUsuario = new SqlParameter("nombreUsuario", SqlDbType.VarChar);
                parameterNombreUsuario.Value = usuario.nombreUsuario;

                var parameterContraseña = new SqlParameter("contraseña", SqlDbType.VarChar);
                parameterContraseña.Value = usuario.contrasena;

                var parameterMail = new SqlParameter("mail", SqlDbType.VarChar);
                parameterMail.Value = usuario.mail;

                var parameterId = new SqlParameter("id", SqlDbType.BigInt);
                parameterId.Value = usuario.id;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.Add(parameterNombre);
                    sqlCommand.Parameters.Add(parameterApellido);
                    sqlCommand.Parameters.Add(parameterNombreUsuario);
                    sqlCommand.Parameters.Add(parameterContraseña);
                    sqlCommand.Parameters.Add(parameterMail);
                    sqlCommand.Parameters.Add(parameterId);
                    rowsAffected = sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            if (rowsAffected == 1)
            {
                resultado = true;
            }
            return resultado;
        }



    }
}