using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Modals
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        [Required(ErrorMessage = "Nombre no puede estar vacio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Inventario no puede estar vacio")]
        [MinLength(4, ErrorMessage = "Inventario no puede ser 0")]
        public int Inventario { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío")]
        public DateTime FechaIngreso { get; set; }
        public Articulos()
        {
            ArticuloId = 0;
            Nombre = string.Empty;
            Inventario = 0;
        }
    }
}
