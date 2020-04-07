using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Models
{
    public class Cobros
    {
        [Key]
        [Required(ErrorMessage = "CobroId no puede estar vacio")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int CobroId { get; set; }
        [Required(ErrorMessage = "Empeño Id no puede estar vacío")]
        public int EmpeñoId { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Abono no puede estar vacío")]
        [Range(minimum: 1, maximum: 999999999999, ErrorMessage = "Abono Fuera de Rango.")]
        public decimal Abono { get; set; }
        [ForeignKey("CobroId")]
        public List<CobrosDetalle> Detalle { get; set; }
        public Cobros()
        {
            this.Detalle = new List<CobrosDetalle>();
            CobroId = 0;
            EmpeñoId = 0;
            Fecha = DateTime.Now;
            Abono = 0;
        }
    }
}
