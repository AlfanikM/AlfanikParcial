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
    public partial class Registro_de_ubicaciones : Form
    {
        public Registro_de_ubicaciones()
        {
            
        }

        private void Registro_de_ubicaciones_Load(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            public static Producto Buscar(int id)
            {
                 db = new Contexto();
                Producto producto = new Producto();

                try
                {
                    producto = db.producto.Find(id);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Dispose();
                }
                return producto;
            }
    }

      
           }
        }
    }
