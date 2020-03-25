using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Models
{
    public class Empeños
    {
        [Key]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int EmpeñoId { get; set; }
        [Required(ErrorMessage = "ClienteId no puede estar vacío")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Nombre Cliente no puede estar vacío")]
        public string NombredeCliente { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Monto Total no puede estar vacío")]
        public decimal MontoTotal { get; set; }

        [Required(ErrorMessage = "Abono no puede estar vacío")]
        [MinLength(1, ErrorMessage = "Abono no puede ser menor que 0")]
        public decimal Abono { get; set; }

        public DateTime UltimaFechadeVigencia { get; set; }
        public List<EmpeñosDetalle> Detalle { get; set; }

        public Empeños()
        {
            this.Detalle = new List<EmpeñosDetalle>();
            EmpeñoId = 0;
            ClienteId = 0;
            NombredeCliente = string.Empty;
            Fecha = DateTime.Now;
            MontoTotal = 0;
            Abono = 0;
            UltimaFechadeVigencia = DateTime.Now;
        }
    }
}
