using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class AccesoDatos
    {
        private string cadenaConexion;

        public AccesoDatos()
        {
            cadenaConexion = "Server=localhost;Database=GestorLibros;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true";
        }

        public DataTable EjecutarConsulta(string nombreSP, SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand comando = new SqlCommand(nombreSP, conn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // VALIDO QUE SE PASEN PARAMETROS
                        if (parametros != null)
                        {
                            comando.Parameters.AddRange(parametros);
                        }

                        SqlDataAdapter da = new SqlDataAdapter(comando);

                        DataTable dt = new DataTable();

                        // PASO EL RESULTADO DEL SELECT A UNA DATATABLE
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al querer conectar con la BD" + ex.Message);
            }
        }

        public int EjecutarNonQuery(string nombreSP, SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand comando = new SqlCommand(nombreSP, conn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        if (parametros != null)
                        {
                            comando.Parameters.AddRange(parametros);
                        }

                        conn.Open();

                        return comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al querer conectar con la BD" + ex.Message);
            }
        }
    }
}
