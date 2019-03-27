using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class Pagos
    {
        [Key]
        public int PagoID { get; set; }
        public int InversionID { get; set; }
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public int Abono { get; set; }
        public int Deuda { get; set; }

        public Pagos()
        {
            PagoID = 0;
            InversionID = 0;
            ClienteID = 0;
            Fecha = DateTime.Now;
            Abono = 0;
        }
    }
}
