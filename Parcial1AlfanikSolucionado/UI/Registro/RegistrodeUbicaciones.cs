using PrimerParcialAlfanik.BLL;
using PrimerParcialAlfanik.DAL;
using PrimerParcialAlfanik.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerParcialAlfanik.UI.Registro
{
    public partial class Registro_de_ubicaciones : Form
    {
        public void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            errorProvider.Clear();
        }

        public Ubicacion LlenaClase()
        {
            Ubicacion ubicaciones = new Ubicacion
            {
                UbicacionId = Convert.ToInt32(IDnumericUpDown.Value),
                Descripcion = DescripciontextBox.Text
            };
            return ubicaciones;
        }

        public void LlenaCampo(Ubicacion ubicaciones)
        {
            IDnumericUpDown.Value = ubicaciones.UbicacionId;
            DescripciontextBox.Text = ubicaciones.Descripcion;
        }

        public void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public bool ExisteEnLaBaseDeDatos()
        {
            Productos productos = BLL.ProductoBLL.Buscar((int)IDnumericUpDown.Value);

            return (productos != null);
        }

        public bool ValidarGuardar()
        {
            bool paso = true;
            errorProvider.Clear();

            if (DescripciontextBox.Text == string.Empty)
            {
                errorProvider.SetError(DescripciontextBox, "El Campo no puede estar vacio.");
                DescripciontextBox.Focus();
                paso = false;
            }
            return paso;
        }

        public bool ValidarEliminar()
        {
            bool paso = true;
            errorProvider.Clear();

            if (IDnumericUpDown.Value == 0)
            {
                errorProvider.SetError(IDnumericUpDown, "Busque otra ubicacion y luego eliminelo.");
                IDnumericUpDown.Focus();
                paso = false;
            }
            return paso;
        }

        public void Gaurdarbutton_Click(object sender, EventArgs e)
        {
            Ubicacion ubicaciones;
            bool paso = false;
            if (!ValidarGuardar())
                return;

            ubicaciones = LlenaClase();


            if (IDnumericUpDown.Value == 0)
                paso = UbicacionesBLL.Guardar(ubicaciones);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede guardar un producto que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = UbicacionesBLL.Modificar(ubicaciones);
            }

            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        public void Eliminarbutton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (!ValidarEliminar())
                return;

            int.TryParse(IDnumericUpDown.Text, out int id);

            Limpiar();

            if (UbicacionesBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                errorProvider.SetError(IDnumericUpDown, "No se puede eliminar ubicacion que no existe.");
        }

        public void Buscarbutton_Click(object sender, EventArgs e)
        {
            Ubicacion Ubicaciones = new Ubicacion();
            int.TryParse(IDnumericUpDown.Text, out int id);

            Limpiar();

            Ubicaciones = UbicacionesBLL.Buscar(id);

            if (Ubicaciones != null)
            {
                MessageBox.Show("Producto Encontrado.");
                LlenaCampo(Ubicaciones);
            }
            else
                MessageBox.Show("Producto no encontrado.");
        }

        private void Registro_de_ubicaciones_Load(object sender, EventArgs e)
        {

        }
    }
}