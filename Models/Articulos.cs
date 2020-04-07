﻿using System;
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
        [Required(ErrorMessage = "ArticuloId no puede estar vacio")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int ArticuloId { get; set; }
        [Required(ErrorMessage = "Nombre no puede estar vacio")]
        public string Nombre { get; set; }
        [Range(minimum: 1, maximum: 999999999999, ErrorMessage = "Debe seleccionar una Categoria para el articulo.")]
        public int CategoriaId { get; set; }
        public int Inventario { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío")]
        public DateTime Fecha { get; set; }

        public Articulos()
        {
            ArticuloId = 0;
            CategoriaId = 0;
            Nombre = string.Empty;
            Inventario = 0;
            Fecha = DateTime.Now;
        }
    }
}
