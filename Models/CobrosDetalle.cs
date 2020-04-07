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
        public int CobroDetalleId { get; set; }
        public int EmpeñoId { get; set; }
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaEmpeño { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal Abono { get; set; }
        public DateTime UltimaFechadeVigencia { get; set; }
        public CobrosDetalle()
        {
            CobroDetalleId = 0;
            EmpeñoId = 0;
        }
        public CobrosDetalle(int id, int empeñoId, int clienteId, string nombreCliente, DateTime fechaEmpeño, int montoTotal, decimal abono)
        {
            CobroDetalleId = id;
            EmpeñoId = empeñoId;
            ClienteId = clienteId;
            NombreCliente = nombreCliente;
            FechaEmpeño = fechaEmpeño;
            MontoTotal = montoTotal;
            Abono = abono;
        }

    }
}
