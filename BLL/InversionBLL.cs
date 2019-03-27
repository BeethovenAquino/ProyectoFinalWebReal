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
    public class InversionBLL
    {
        public static bool Guardar(Inversionn inversion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.inversion.Add(inversion) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }




        public static bool Modificar(Inversionn inversion)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(inversion).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
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
                Inversionn inversion = contexto.inversion.Find(id);

                if (inversion != null)
                {
                    contexto.Entry(inversion).State = EntityState.Deleted;
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


        public static Inversionn Buscar(int id)
        {

            Inversionn inversion = new Inversionn();
            Contexto contexto = new Contexto();

            try
            {
                inversion = contexto.inversion.Find(id);
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return inversion;

        }



        public static List<Inversionn> GetList(Expression<Func<Inversionn, bool>> expression)
        {
            List<Inversionn> inversion = new List<Inversionn>();
            Contexto contexto = new Contexto();

            try
            {
                inversion = contexto.inversion.Where(expression).ToList();
                contexto.Dispose();

            }
            catch (Exception) { throw; }
            return inversion;
        }
    }
}
