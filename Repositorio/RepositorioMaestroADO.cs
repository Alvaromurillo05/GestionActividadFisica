using Entidades;
using System.Configuration;
using System.Data.SqlClient;

namespace Repositorio
{
    public class RepositorioMaestroADO : IRepositorioMaestro
    {
        public List<Ciudad> ObtenerCiudades()
        {
            var ciudades = new List<Ciudad>();

            using (var conexion = new SqlConnection(ConfigurationManager.
                ConnectionStrings["GestionActividadFisica"].ConnectionString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT Id, Nombre FROM Ciudades ORDER BY Nombre";
                comando.Connection = conexion;

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ciudades.Add(new Ciudad()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = Convert.ToString(reader["Nombre"])
                        });
                    }
                }

            }

            return ciudades;
        }

        public List<TipoDocumento> ObtenerTiposDocumento()
        {
            var tiposDocumento = new List<TipoDocumento>();

            using (var conexion = new SqlConnection(ConfigurationManager.
                ConnectionStrings["GestionActividadFisica"].ConnectionString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT Id, Nombre FROM TiposDocumento ORDER BY Nombre";
                comando.Connection = conexion;

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tiposDocumento.Add(new TipoDocumento()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = Convert.ToString(reader["Nombre"])
                        });
                    }
                }

            }

            return tiposDocumento;
        }
    }
}
