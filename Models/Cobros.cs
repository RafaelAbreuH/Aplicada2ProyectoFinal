using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Models
{
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }
        public int EmpeñoId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Abono { get; set; }

        public Cobros()
        {
            CobroId = 0;
            EmpeñoId = 0;
            Fecha = DateTime.Now;
            Abono = 0;
        }
    }
}
