using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EntradaInversion
    {
        [Key]
        public int EntradaInversionID { get; set; }
        public int InversionID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }

        public EntradaInversion()
        {
            EntradaInversionID = 0;
            InversionID = 0;
            Fecha = DateTime.Now;
            Monto = 0;
        }
    }
}
