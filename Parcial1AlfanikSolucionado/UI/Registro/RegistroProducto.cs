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
using PrimerParcialAlfanik.UI.Registro;

namespace PrimerParcialAlfanik.UI.Registro
{
    public partial class RegistroProducto : Form
    {
        public RegistroProducto()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = string.Empty;
          
        }

        public bool ValidarCampos()
        {
            bool validar = true;

            if (string.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                errorProvider.SetError(DescripcionTextBox, "Llenar descripcion del Producto");
                validar = false;
            }
            if (string.IsNullOrEmpty(ExistenciaNumericUpDown.Text) || ExistenciaNumericUpDown.Text == "0")
            {
                errorProvider.SetError(ExistenciaNumericUpDown, "Llenar Existencia del Producto");
                validar = false;
            }
            if (string.IsNullOrEmpty(CostoNumericUpDown.Text) || CostoNumericUpDown.Text == "0")
            {
                errorProvider.SetError(CostoNumericUpDown, "Llenar Costo del Producto");
                validar = false;
            }
            return validar;
        }

        public bool ValidarBuscar()
        {
            if (IdNumericUpDown.Value <= 0)
            {
                return false;
            }
            if (ProductoBLL.Buscar(Convert.ToInt32(IdNumericUpDown.Value)) == null)
            {
                return false;
            }
            return true;
        }

        public bool ValidarEliminar()
        {
            return ValidarBuscar();
        }

        public bool ValidarGuardar()
        {
            if (!ValidarCampos())
            {
                return false;
            }
            return true;
        }

        public Productos LlenaClase()
        {
            Productos producto = new Productos
            {
                Descripcion = DescripcionTextBox.Text,
                Existencia = Convert.ToInt32(ExistenciaNumericUpDown.Text),
                Costo = Convert.ToDouble(CostoNumericUpDown.Text),
                ValorInventario = Convert.ToDouble(ValorInvTextBox.Text),
                ProductosId = Convert.ToInt32(IdNumericUpDown.Value),
            };
            return producto; 
        }

        public void LlenaCampos(Productos producto)
        {
            DescripcionTextBox.Text = producto.Descripcion;
            ExistenciaNumericUpDown.Text = producto.Existencia.ToString();
            CostoNumericUpDown.Text = producto.Costo.ToString();
            ValorInvTextBox.Text = producto.ValorInventario.ToString();
            IdNumericUpDown.Value = producto.ProductosId;
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
            if (ValidarEliminar())
            {
                if (ProductoBLL.Eliminar(Convert.ToInt32(IdNumericUpDown.Value)))
                {
                    MessageBox.Show("Registro Eliminado Correctamente!");
                    Limpiar();
                    return;
                }

                MessageBox.Show("Error al intentar eliminar el registro!");
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            if (ValidarBuscar() == false)
            {
                MessageBox.Show("No existe un producto con este ID");
                return;
            }
            LlenaCampos(ProductoBLL.Buscar(Convert.ToInt32(IdNumericUpDown.Value)));
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Registro_de_ubicaciones rubi = new Registro_de_ubicaciones();
            rubi.ShowDialog();
        }

        private void RegistroProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
