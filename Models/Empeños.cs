using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Models
{
    public class Empeños
    {
        [Key]
        [Required(ErrorMessage = "EmpeñoId no puede estar vacio")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int EmpeñoId { get; set; }
        [Required(ErrorMessage = "Debe Selecionar un cliente")]
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
        [Range(minimum: 1, maximum: 999999999999, ErrorMessage = "Abono Fuera de rango")]
        public decimal Abono { get; set; }
        public DateTime UltimaFechadeVigencia { get; set; }
        [ForeignKey("EmpeñoId")]
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
