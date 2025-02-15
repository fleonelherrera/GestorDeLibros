using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LibroModel
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Genero { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Editorial { get; set; }
        public string Estado { get; set; }
        public decimal Precio { get; set; }
        public string UrlImagen { get; set; }
    }
}
