using PrimerParcialAlfanik.BLL;
using PrimerParcialAlfanik.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerParcialAlfanik.UI.Registro
{
    public partial class RegistroProducto : Form
    {
        public  RegistroProducto()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = string.Empty;

        }

        private RegistroUbicacion LlenaClase()
        {
            RegistroUbicacion producto = new RegistroUbicacion();
            RegistroUbicacion.id = Convert.ToInt32(IdNumericUpDown.Value);
            RegistroUbicacion.Descripcion = DescripcionTextBox.Text;

            return producto;
        }

        private void LlenaCampo(RegistroUbicacion registroUbicacion)

        {
            IdNumericUpDown.Value = id.Id;
            DescripcionTextBox.Text = DescripcionTextBox.text;

        }


        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if (IdNumericUpDown.Value == 0)
                paso = BLL.ProductoBLL.Guardar(LlenaClase());
            else
                paso = BLL.ProductoBLL.Modificar(LlenaClase());

            Limpiar();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (!ValidarEliminar())
                return;

            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            if (RegistroUbicacion.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                errorProvider.SetError(IdNumericUpDown, "Ubicacion no existe");
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            RegistroUbicacion registroUbicacion = new RegistroUbicacion();
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            producto = RegistroUbicacion.Buscar(id);

            if (id != null)
            {
                MessageBox.Show("Ubicacion no Encontrada!!!");
                LlenaCampo(id);
            }
            else
                MessageBox.Show("Ubicacion no encontrada!!!");
        }


    }
}