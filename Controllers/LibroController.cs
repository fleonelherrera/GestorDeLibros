using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    public class LibroController
    {
        private AccesoDatos datos = new AccesoDatos();

        public DataTable ListarLibros()
        {
            try
            {
                // PARAMETROS
                SqlParameter[] parametros = new SqlParameter[] {
                    new SqlParameter("@i_c_operacion", "C")
                };

                DataTable dt = datos.EjecutarConsulta("sp_ABM_libros", parametros);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AgregarLibro(LibroModel libro)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@i_c_operacion", "A"),
                    new SqlParameter("@i_d_titulo", libro.Titulo),
                    new SqlParameter("@i_d_autor", libro.Autor),
                    new SqlParameter("@i_n_id_genero", libro.Genero),
                    new SqlParameter("@i_f_publicacion", libro.FechaPublicacion),
                    new SqlParameter("@i_d_editorial", libro.Editorial),
                    new SqlParameter("@i_m_estado", libro.Estado),
                    new SqlParameter("@i_n_precio", libro.Precio),
                    new SqlParameter("@i_d_url_imagen", libro.UrlImagen)
                };

                int respuesta = datos.EjecutarNonQuery("sp_ABM_libros", parametros);

                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
        public int EditarLibro(int id, LibroModel libroModificado)
        {

        }

        public int EliminarLibro(int id)
        {

        }
        */
    }
}
