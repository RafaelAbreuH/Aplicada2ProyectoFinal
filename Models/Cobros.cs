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
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int CobroId { get; set; }
        [Required(ErrorMessage = "Empeño Id no puede estar vacío")]
        public int EmpeñoId { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Abono no puede estar vacío")]
        [MinLength(0, ErrorMessage = "Abono no puede ser 0")]
        public decimal Abono { get; set; }
        public List<CobrosDetalle> Detalle { get; set; }

        public Cobros()
        {
            CobroId = 0;
            EmpeñoId = 0;
            Fecha = DateTime.Now;
            Abono = 0;
        }
    }
}
