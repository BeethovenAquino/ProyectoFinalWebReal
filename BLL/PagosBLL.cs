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
    public class PagosBLL
    {
        public static bool Guardar(Pagos pagos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.pagos.Add(pagos) != null)
                {

                    contexto.Cliente.Find(pagos.ClienteID).Total -= pagos.Abono;

                    contexto.inversion.Find(pagos.InversionID).Monto += pagos.Abono;

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
                Pagos pagos = contexto.pagos.Find(id);

                if (pagos != null)
                {
                    contexto.Cliente.Find(pagos.ClienteID).Total += pagos.Abono;

                    contexto.inversion.Find(pagos.InversionID).Monto -= pagos.Abono;
                    contexto.Entry(pagos).State = EntityState.Deleted;

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



        public static bool Editar(Pagos pagos)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {


                Pagos Anterior = BLL.PagosBLL.Buscar(pagos.PagoID);


                int diferencia;




                diferencia = Anterior.Abono + pagos.Abono;
                decimal otradif = Anterior.Abono - pagos.Abono;


                Cliente cliente = ClienteBLL.Buscar(pagos.ClienteID);
                cliente.Total = Math.Abs(cliente.Total - diferencia);

                Inversion negocio = BLL.InversionBLL.Buscar(pagos.InversionID);
                if (Anterior.Abono < pagos.Abono)
                {

                    negocio.Monto += diferencia;
                }
                else
                {

                    negocio.Monto = negocio.Monto - otradif;
                }

                BLL.InversionBLL.Modificar(negocio);

                contexto.Entry(pagos).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }
        public static Pagos Buscar(int id)
        {

            Pagos pagos = new Pagos();
            Contexto contexto = new Contexto();

            try
            {

                pagos = contexto.pagos.Find(id);
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return pagos;

        }



        public static List<Pagos> GetList(Expression<Func<Pagos, bool>> expression)
        {
            List<Pagos> pagos = new List<Pagos>();
            Contexto contexto = new Contexto();

            try
            {
                pagos = contexto.pagos.Where(expression).ToList();
                contexto.Dispose();

            }
            catch (Exception) { throw; }
            return pagos;
        }
    }
}
