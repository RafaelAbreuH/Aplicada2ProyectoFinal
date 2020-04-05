using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Models
{
    public class Categorias
    {
        [Key]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "Descripcion no puede estar vacio")]
        public string Nombre { get; set; }
 
        public Categorias()
        {
            CategoriaId = 0;
            Nombre = string.Empty;
         
        }
    }
}
