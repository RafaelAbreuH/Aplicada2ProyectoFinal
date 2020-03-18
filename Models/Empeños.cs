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
        public int EmpeñoId { get; set; }
        public int ClienteId { get; set; }
        public string NombredeCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal Abono { get; set; }
        public DateTime UltimaFechadeVigencia { get; set; }
        public virtual ICollection<EmpeñosDetalle> Detalle { get; set; }

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
        public void AgregarDetalle(int Id, int reciboId, int articuloId, string articulo, string descripcion, int cantidad, decimal monto)
        {
            Detalle.Add(new EmpeñosDetalle(Id, reciboId, articuloId, articulo, descripcion, cantidad, monto));
        }
    }
}
