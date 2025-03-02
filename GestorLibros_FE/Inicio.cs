using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;
using Models;

namespace GestorLibros_FE
{
    public partial class Inicio : Form
    {
        LibroController libroController = new LibroController();

        public Inicio()
        {
            InitializeComponent();
            CargarLibros();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarLibro agregarLibro = new AgregarLibro();
            agregarLibro.ShowDialog();
        }

        public void CargarLibros()
        {
            DataTable dt = libroController.ListarLibros();
            dgvLibros.DataSource = dt;

            // OCULTO LA COLUMNA URL IMAGEN
            dgvLibros.Columns["URL IMAGEN"].Visible = false;

            // CARGO LA IMAGEN
            string urlImagen = dt.Rows[0]["URL IMAGEN"].ToString();
            CargarImagen(urlImagen);
        }


        private void CargarImagen(string imagen)
        {
            try
            {
                pbPortada.Load(imagen);
            }
            catch (Exception)
            {
                pbPortada.Load("https://static.vecteezy.com/system/resources/previews/005/337/799/original/icon-image-not-found-free-vector.jpg");
            }
        }

        private void dgvLibros_SelectionChanged(object sender, EventArgs e)
        {
            string urlImagen = dgvLibros.CurrentRow.Cells["URL IMAGEN"].Value?.ToString();

            CargarImagen(urlImagen);

            btnEditar.Enabled = true;
        }
    }
}
