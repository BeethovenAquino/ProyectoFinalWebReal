using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Inversion
    {
        [Key]
        public int InversionID { get; set; }
        public decimal Monto { get; set; }

        public Inversion()
        {
            InversionID = 0;
            Monto = 0;
        }
    }
}
