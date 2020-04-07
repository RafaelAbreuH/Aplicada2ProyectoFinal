using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Models
{
    public class TiposUsuarios
    {
        [Key]
        [Required(ErrorMessage = "TipoUsuarioId no puede estar vacio")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int TipoUsuarioId { get; set; }
        [Required(ErrorMessage = "Descripcion no puede estar vacia")]
        public string Descripcion { get; set; }
        public TiposUsuarios()
        {
            TipoUsuarioId = 0;
            Descripcion = string.Empty;
        }
    }
}
