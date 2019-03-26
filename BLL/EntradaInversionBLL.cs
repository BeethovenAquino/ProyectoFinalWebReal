using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class EntradaInversionBLL
    {
        public static bool Guardar(EntradaInversion entradaInversion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.entradaInversion.Add(entradaInversion) != null)
                {

                    var activo = contexto.inversion.Find(entradaInversion.InversionID);

                    activo.Monto += entradaInversion.Monto;

                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }


        public static bool Eliminar(int id)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                EntradaInversion entrada = contexto.entradaInversion.Find(id);

                if (entrada != null)
                {
                    var activo = contexto.inversion.Find(entrada.InversionID);

                    activo.Monto -= entrada.Monto;

                    contexto.Entry(entrada).State = EntityState.Deleted;

                }

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();
                }


            }
            catch (Exception) { throw; }

            return paso;
        }



        public static bool Editar(EntradaInversion entrada)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {


                EntradaInversion EntradaAnterior = BLL.EntradaInversionBLL.Buscar(entrada.EntradaInversionID);

                //identificar la diferencia ya sea restada o sumada
                decimal diferencia;
                diferencia = entrada.Monto - EntradaAnterior.Monto;

                //Buscar
                var capitaldeNegocios = contexto.inversion.Find(EntradaAnterior.InversionID);

                //aplicar diferencia al inventario 
                capitaldeNegocios.Monto += diferencia;




                contexto.Entry(entrada).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }



        public static EntradaInversion Buscar(int id)
        {

            EntradaInversion entrada = new EntradaInversion();
            Contexto contexto = new Contexto();

            try
            {
                entrada = contexto.entradaInversion.Find(id);
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return entrada;

        }



        public static List<EntradaInversion> GetList(Expression<Func<EntradaInversion, bool>> expression)
        {
            List<EntradaInversion> entrada = new List<EntradaInversion>();
            Contexto contexto = new Contexto();

            try
            {
                entrada = contexto.entradaInversion.Where(expression).ToList();
                contexto.Dispose();

            }
            catch (Exception) { throw; }
            return entrada;
        }
    }
}
