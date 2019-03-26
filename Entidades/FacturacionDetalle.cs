using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class FacturacionDetalle
    {
        
            [Key]
            public int ID { get; set; }
            public int FacturaID { get; set; }
            public int ClienteID { get; set; }
            public int ArticuloID { get; set; }
            public string Venta { get; set; }
            public string Cliente { get; set; }
            public string Articulo { get; set; }
            public int Cantidad { get; set; }
            public int Precio { get; set; }
            public int Importe { get; set; }


            [ForeignKey("ArticuloID")]
            public virtual Articulos Articulos { get; set; }


            public FacturacionDetalle()
            {
                ID = 0;
                FacturaID = 0;
            
            }

            public FacturacionDetalle(int iD, int facturaID, int clienteID, int articuloID, string venta, string cliente, string articulo, int cantidad, int precio, int importe)
            {
                ID = iD;
                FacturaID = facturaID;
                ClienteID = clienteID;
                ArticuloID = articuloID;
                Venta = venta;
                Cliente = cliente;
                Articulo = articulo;
                Cantidad = cantidad;
                Precio = precio;
                Importe = importe;
            }

        }
    }
