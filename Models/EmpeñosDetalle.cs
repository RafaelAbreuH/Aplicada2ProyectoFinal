using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Models
{
    public class EmpeñosDetalle
    {
        [Key]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int ID { get; set; }

        [Required(ErrorMessage = "EmpeñoId no puede estar vacío")]
        [MinLength(1, ErrorMessage = "Empeño Id no existe")]
        public int EmpeñoId { get; set; }
        
        [Required(ErrorMessage = "ArticuloId no puede estar vacío")]
        [MinLength(1, ErrorMessage = "Articulo Id no Existe")]
        public int ArticuloId { get; set; }
        [Required(ErrorMessage = "Articulo no puede estar vacío")]
        public string Articulo { get; set; }
        [Required(ErrorMessage = "Descripcion no puede estar vacío")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Cantidad no puede estar vacío")]
        [MinLength(1, ErrorMessage = "Cantidad no puede ser 0")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Monto no puede estar vacío")]
        [MinLength(1, ErrorMessage = "Monto no puede ser 0")]
        public decimal Monto { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulos Articulos { get; set; }
        public EmpeñosDetalle()
        {
            ID = 0;
            EmpeñoId = 0;
        }
        public EmpeñosDetalle(int Id, int reciboId, int articuloId, string articulo, string descripcion, int cantidad, decimal monto)
        {
            ID = Id;
            EmpeñoId = reciboId;
            ArticuloId = articuloId;
            Articulo = articulo;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Monto = monto;
        }
    }
}
