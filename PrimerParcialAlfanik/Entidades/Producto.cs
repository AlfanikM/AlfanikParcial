using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrimerParcialAlfanik.Entidades
{
    public class Producto
    {
        [Key]

     public   int  Id { get; set; } 
     public   string Descripcion { get; set; }
    
    
        public Producto()
        {
            Id = 0;
            Descripcion =0;
            
        }

    }
}
