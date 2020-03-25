using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Models
{
    public class CobrosDetalle
    {
        [Key]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int CobrosDetalleId { get; set; }
        public int EmpeñoId { get; set; }
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaEmpeño { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal Abono { get; set; }
        public DateTime UltimaFechadeVigencia { get; set; }
        [ForeignKey("EmpeñoId")]
        public List<Empeños> Empeños { get; set; }
        public CobrosDetalle()
        {

        }

    }
}
