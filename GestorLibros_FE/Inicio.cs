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
        }
    }
}
