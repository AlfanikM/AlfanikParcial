using PrimerParcialAlfanik.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcialAlfanik.DAL
{
   public class Contexto : DbContext
    {
        public DbSet<Producto> producto { get; set; }
        
        public Contexto() : base("ConStr") { }
    }
}
