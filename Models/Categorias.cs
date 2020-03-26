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
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "Descripcion no puede estar vacia")]
        public string Descripcion { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío")]
        public DateTime Fecha { get; set; }

        public Categorias()
        {
            CategoriaId = 0;
            Descripcion = string.Empty;
            Fecha = DateTime.Now;
        }

    }
}
