using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Models
{
    public class Articulos
    {
        [Key]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int ArticuloId { get; set; }
        [Required(ErrorMessage = "Nombre no puede estar vacio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = " Debe elegir una categoria para el articulo")]
        public int CategoriaId { get; set; }
        public decimal Inventario { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío")]
        public DateTime Fecha { get; set; }
        [ForeignKey("CategoriaId")]
        public List <Categorias> ListadoCategorias { get; set; }

        public Articulos()
        {
            this.ListadoCategorias = new List<Categorias>();
            ArticuloId = 0;
            CategoriaId = 0;
            Nombre = string.Empty;
            Inventario = 0;
            Fecha = DateTime.Now;
        }
    }
}
