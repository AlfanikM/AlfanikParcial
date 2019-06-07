using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcialAlfanik.Entidades
{
    public class Ubicacion
    {
        [Key]
        public int UbicacionId { get; set; }
        public string Descripcion { get; set; }

        public Ubicacion()
        {
            UbicacionId = 0;
            Descripcion = string.Empty;
        }
    }
}
