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
    public class EntradaArticulosBLL
    {
        public static bool Guardar(EntradaArticulos entradaAriticulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.EntradaArticulos.Add(entradaAriticulos) != null)
                {
                    Articulos articulo = ArticulosBLL.Buscar(entradaAriticulos.ArticuloID);
                    articulo.Vigencia += entradaAriticulos.Cantidad;
                    articulo.PrecioCompra += entradaAriticulos.PrecioCompra;
                    articulo.PrecioVenta += entradaAriticulos.PrecioVenta;
                    articulo.Ganancia += entradaAriticulos.Ganancia;
                    BLL.ArticulosBLL.Modificar(articulo);


                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public static bool Modificar(EntradaArticulos entradaAriticulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {

                EntradaArticulos EntradaAnterior = BLL.EntradaArticulosBLL.Buscar(entradaAriticulos.EntradaArticulosID);

                //identificar la diferencia ya sea restada o sumada
                int Restar;
                int c;
                int v;
                int g;

                Restar = entradaAriticulos.Cantidad - EntradaAnterior.Cantidad;
                c = entradaAriticulos.PrecioCompra - EntradaAnterior.PrecioCompra;
                v = entradaAriticulos.PrecioVenta - EntradaAnterior.PrecioVenta;
                g = entradaAriticulos.Ganancia - EntradaAnterior.Ganancia;

                //aplicar diferencia al inventario
                Articulos articulo = BLL.ArticulosBLL.Buscar(entradaAriticulos.ArticuloID);
                articulo.Vigencia += Restar;
                articulo.PrecioCompra += c;
                articulo.Ganancia += g;
                BLL.ArticulosBLL.Modificar(articulo);

                contexto.Entry(entradaAriticulos).State = EntityState.Modified;



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
                EntradaArticulos entradaAriticulos = contexto.EntradaArticulos.Find(id);



                if (entradaAriticulos != null)
                {
                    Articulos articulo = BLL.ArticulosBLL.Buscar(entradaAriticulos.ArticuloID);
                    articulo.Vigencia -= entradaAriticulos.Cantidad;
                    BLL.ArticulosBLL.Modificar(articulo);

                    contexto.Entry(entradaAriticulos).State = EntityState.Deleted;
                }

                if (contexto.SaveChanges() > 0)
                {
                    contexto.Dispose();
                    paso = true;
                }


            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static EntradaArticulos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            EntradaArticulos entradaAriticulos = new EntradaArticulos();
            try
            {
                entradaAriticulos = contexto.EntradaArticulos.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return entradaAriticulos;
        }

        public static List<EntradaArticulos> GetList(Expression<Func<EntradaArticulos, bool>> expression)
        {
            List<EntradaArticulos> entradaAriticulos = new List<EntradaArticulos>();
            Contexto contexto = new Contexto();
            try
            {
                entradaAriticulos = contexto.EntradaArticulos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return entradaAriticulos;
        }

        public static string RetornarArticulo(string Articulo)
        {
            string articulo = string.Empty;
            var lista = GetList(x => x.Articulo.Equals(Articulo));
            foreach (var item in lista)
            {
                articulo = item.Articulo;
            }

            return Articulo;
        }


        public static int CalcularGanancia(int precioVenta, int precioCompra)
        {

            return ((Convert.ToInt32(precioVenta) - Convert.ToInt32(precioCompra)));

        }
    }
}
