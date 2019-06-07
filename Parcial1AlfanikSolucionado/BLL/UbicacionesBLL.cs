using PrimerParcialAlfanik.DAL;
using PrimerParcialAlfanik.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrimerParcialAlfanik.BLL
{
   public class UbicacionesBLL
    {
        public static bool Guardar(Ubicacion Ubicacion)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Ubicacion.Add(Ubicacion) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Ubicacion Ubicacion)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(Ubicacion).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static Ubicacion Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ubicacion Ubicacion = new Ubicacion();
            try
            {
                Ubicacion = contexto.Ubicacion.Find(id);
            }
            catch
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return Ubicacion;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Ubicacion.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

    }
}
