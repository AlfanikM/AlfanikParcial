using PrimerParcialAlfanik.Entidades;
using PrimerParcialAlfanik.UI.Registro;
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
        public DbSet<Productos> Producto { get; set; }
        public DbSet<Ubicacion> Ubicacion { get; set; }
        public DbSet<Inventarios> Inventario { get; set; }

        public Contexto() : base("ConStr") { }
    }
}
