using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class EntradaArticulos
    {
        [Key]
        public int EntradaArticulosID { get; set; }
        public string Articulo { get; set; }
        public int Cantidad { get; set; }
        public int ArticuloID { get; set; }
        public int PrecioCompra { get; set; }
        public int PrecioVenta { get; set; }
        public int Ganancia { get; set; }


        public EntradaArticulos()
        {
            EntradaArticulosID = 0;
            Articulo = string.Empty;
            Cantidad = 0;
            PrecioCompra = 0;
            PrecioVenta = 0;
            Ganancia = 0;
        }
    }
}
