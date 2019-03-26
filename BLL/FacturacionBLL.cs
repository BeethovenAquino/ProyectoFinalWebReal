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
    public class FacturacionBLL
    {
        public static bool Guardar(Facturacion facturacion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Cliente cliente = new Cliente();

            try
            {
                if (contexto.Facturacion.Add(facturacion) != null)
                {
                    foreach (var item in facturacion.Detalle)
                    {
                        contexto.Articulos.Find(item.ArticuloID).Vigencia -= item.Cantidad;
                    }



                    var inversion = contexto.inversion.Find(facturacion.InversionID);

                    //Este bloque de codigo afecta la inversion de forma positiva cuando la facturacion es saldada en el mismo momento que se genera
                    if (facturacion.Total == facturacion.Abono)
                    {
                        inversion.Monto += facturacion.Total;
                        contexto.Entry(inversion).State = EntityState.Modified;
                    }
                    else
                    {
                        contexto.Cliente.Find(facturacion.ClienteID).Total += facturacion.Total;
                        inversion.Monto -= facturacion.Total;
                    }

                    //SaveChanges retorna un entero que indica la cantidad de filas que han sido afectadas,es decir que si es mayor que cero todo salio bien.
                    paso = contexto.SaveChanges() > 0;

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

                Facturacion facturacion = contexto.Facturacion.Find(id);

                if (facturacion != null)
                {

                    foreach (var item in facturacion.Detalle)
                    {
                        var articulo = contexto.Articulos.Find(item.ArticuloID);
                        articulo.Vigencia += item.Cantidad;
                    }

                    int totalactual = Convert.ToInt32(facturacion.Total);
                    int totalanterior = Convert.ToInt32(contexto.Cliente.Find(facturacion.ClienteID).Total);
                    if (totalactual > totalanterior)
                    {
                        contexto.Cliente.Find(facturacion.ClienteID).Total = 0;

                    }
                    else
                    {
                        contexto.Cliente.Find(facturacion.ClienteID).Total -= facturacion.Total;

                    }

                    contexto.inversion.Find(facturacion.InversionID).Monto -= facturacion.Total;
                    facturacion.Detalle.Count();


                    contexto.Facturacion.Remove(facturacion);
                }
                if (contexto.SaveChanges() > 0)
                {
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

        public static Facturacion Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Facturacion facturacion = new Facturacion();
            try
            {
                facturacion = contexto.Facturacion.Find(id);
                if (facturacion != null)
                {
                    //Cargar la lista en este punto porque
                    //luego de hacer Dispose() el Contexto 
                    //no sera posible leer la lista
                    facturacion.Detalle.Count();

                    ////Cargar los nombres de las ciudades
                    //foreach (var item in facturacion.Detalle)
                    //{
                    //    //forzando la ciudad a cargarse
                    //    string s = item..Descripcion;
                    //}

                    contexto.Dispose();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return facturacion;
        }





        public static List<Facturacion> GetList(Expression<Func<Facturacion, bool>> expression)
        {
            List<Facturacion> facturacion = new List<Facturacion>();
            Contexto contexto = new Contexto();
            try
            {
                facturacion = contexto.Facturacion.Where(expression).ToList();
                //contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return facturacion;
        }

        public static bool Modificar(Facturacion facturacion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //todo: buscar las entidades que no estan para removerlas
                var visitaant = FacturacionBLL.Buscar(facturacion.FacturaID);

                foreach (var item in visitaant.Detalle)//recorrer el detalle aterior
                {
                    //restar todas las visitas
                    contexto.Articulos.Find(item.ArticuloID).Vigencia += item.Cantidad;



                    //determinar si el item no esta en el detalle actual
                    if (!facturacion.Detalle.ToList().Exists(v => v.ID == item.ID))
                    {
                        //   contexto.Articulos.Find(item.ArticulosID).Inventario -= item.Cantidad;
                        item.Articulos = null; //quitar la ciudad para que EF no intente hacerle nada
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }
                var inversion = contexto.inversion.Find(facturacion.InversionID);

                if (facturacion.Total == facturacion.Abono)
                {
                    inversion.Monto += facturacion.Total;
                    contexto.Entry(inversion).State = EntityState.Modified;
                }
                else
                {
                    contexto.Cliente.Find(facturacion.ClienteID).Total += facturacion.Total;
                    inversion.Monto -= facturacion.Total;


                    Cliente EntradaAnterior = BLL.ClienteBLL.Buscar(facturacion.ClienteID);
                    //identificar la diferencia ya sea restada o sumada
                    int diferencia;

                    diferencia = facturacion.Total - EntradaAnterior.Total;

                    //aplicar diferencia al inventario
                    Cliente cliente = BLL.ClienteBLL.Buscar(facturacion.ClienteID);
                    cliente.Total += diferencia;
                    ClienteBLL.Modificar(cliente);



                    Facturacion EntradaAnteri = BLL.FacturacionBLL.Buscar(facturacion.FacturaID);


                    //identificar la diferencia ya sea restada o sumada
                    int diferenc;

                    diferenc = facturacion.Total - EntradaAnteri.Total;

                    //aplicar diferencia al inventario
                    Inversion fact = InversionBLL.Buscar(facturacion.InversionID);
                    fact.Monto += diferenc;
                    InversionBLL.Modificar(fact);


                }
                //recorrer el detalle

                foreach (var item in facturacion.Detalle)
                {
                    //Sumar todas las visitas
                    contexto.Articulos.Find(item.ArticuloID).Vigencia -= item.Cantidad;

                    //Muy importante indicar que pasara con la entidad del detalle
                    var estado = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }



                Facturacion EntradaAnterio = BLL.FacturacionBLL.Buscar(facturacion.FacturaID);


                //identificar la diferencia ya sea restada o sumada
                int diferenci;

                diferenci = facturacion.Total - EntradaAnterio.Total;

                //aplicar diferencia al inventario
                Inversion factu = InversionBLL.Buscar(facturacion.InversionID);
                factu.Monto += diferenci;
                InversionBLL.Modificar(factu);

                //Idicar que se esta modificando el encabezado
                contexto.Entry(facturacion).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
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

        public static int CalcularImporte(int precio, int cantidad)
        {
            return Convert.ToInt32(precio) * Convert.ToInt32(cantidad);
        }

        public static decimal CalcularDevuelta(int Monto, int Precio)
        {
            return Convert.ToInt32(Monto) - Convert.ToInt32(Precio);
        }
    }
}
