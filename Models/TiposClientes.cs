using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Models
{
    public class TiposClientes
    {
        [Key]
        [Required(ErrorMessage = "TipoClienteId no puede estar vacio")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int TipoClienteId { get; set; }
        [Required(ErrorMessage = "Descripcion no puede estar vacia")]
        public string Descripcion { get; set; }
        public TiposClientes()
        {
            TipoClienteId = 0;
            Descripcion = string.Empty;
        }
    }
}
