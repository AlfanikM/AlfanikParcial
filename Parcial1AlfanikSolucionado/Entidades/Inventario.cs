using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcialAlfanik.Entidades
{
    public class Inventarios
    {
        [Key]
        public int InventarioId { get; set; }
        public Double ValorInventario { get; set; }

        public Inventarios(double valorInventario)
        {
            ValorInventario = valorInventario;
        }

        public Inventarios()
        {

        }
    }
}
