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
    public partial class AgregarLibro : Form
    {
        LibroController libroController = new LibroController();

        public AgregarLibro()
        {
            InitializeComponent();
            CargarCombos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ValidarCampos();

            LibroModel libroAAgregar = new LibroModel();

            libroAAgregar.Titulo = txtTitulo.Text;
            libroAAgregar.Autor = txtAutor.Text;
            libroAAgregar.Genero = AsignarGenero(cboGenero.SelectedIndex);

            DateTime anioPublicacion = new DateTime(Convert.ToInt32(nupAnio.Value), 1, 1);
            libroAAgregar.FechaPublicacion = anioPublicacion;

            libroAAgregar.Editorial = txtEditorial.Text;
            libroAAgregar.Estado = AsignarEstado(cboEstado.SelectedIndex);
            libroAAgregar.Precio = nupPrecio.Value;
            libroAAgregar.UrlImagen = txtUrlImagen.Text;

            libroController.AgregarLibro(libroAAgregar);
            this.Close();

        }

        private void ValidarCampos()
        {
            if (txtTitulo.Text == "")
            {
                MessageBox.Show("El titulo es obligatorio");
                txtTitulo.Focus();
                return;
            }

            if (txtTitulo.TextLength > 100)
            {
                MessageBox.Show("El titulo no puede tener mas de 100 caracteres");
                txtTitulo.Focus();
            }

            if (txtAutor.Text == "")
            {
                MessageBox.Show("El autor es obligatorio");
                txtAutor.Focus();
            }

            if (txtAutor.TextLength > 100)
            {
                MessageBox.Show("El autor no puede tener mas de 100 caracteres");
                txtAutor.Focus();
                return;
            }

            if (cboGenero.SelectedIndex == -1)
            {
                MessageBox.Show("El genero es obligatorio");
                cboGenero.Focus();
                return;
            }

            if (nupAnio.Value < 1000 && nupAnio.Value > 2026)
            {
                MessageBox.Show("El año es invalido");
                nupAnio.Focus();
                return;
            }

            if (cboEstado.SelectedIndex == -1)
            {
                MessageBox.Show("El estado es obligatorio");
                cboEstado.Focus();
                return;
            }

            if (nupPrecio.Value == 0)
            {
                MessageBox.Show("El precio no puede ser cero");
                nupPrecio.Focus();
                return;
            }
        }

        private void CargarCombos()
        {
            cboGenero.Items.Add("Ficción");
            cboGenero.Items.Add("Ciencia ficción");
            cboGenero.Items.Add("Misterio");
            cboGenero.Items.Add("Romántico");
            cboGenero.Items.Add("Fantasía");
            cboGenero.Items.Add("Terror");
            cboGenero.Items.Add("Histórico");
            cboGenero.Items.Add("Drama");
            cboGenero.Items.Add("Aventura");
            cboGenero.Items.Add("Thriller");

            cboEstado.Items.Add("Nuevo");
            cboEstado.Items.Add("Usado");
        }

        private int AsignarGenero(int generoSeleccionado)
        {
            switch (generoSeleccionado)
            {
                case 0: return 1;
                case 1: return 2;
                case 2: return 3;
                case 3: return 4;
                case 4: return 5;
                case 5: return 6;
                case 6: return 7;
                case 7: return 8;
                case 8: return 9;
                case 9: return 10;
                default: return 0; // NUNCA SE VA A CUMPLIR
            }
        }

        private string AsignarEstado(int estadoSeleccionado)
        {
            switch (estadoSeleccionado)
            {
                case 0: return "N";
                case 1: return "U";
                default: return "A"; // NUNCA SE VA A CUMPLIR
            }
        }
    }
}
