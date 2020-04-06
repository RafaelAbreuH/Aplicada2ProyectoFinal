﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Models
{
    public class Clientes
    {
        [Key]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Nombre no puede estar vacío")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Cedula no puede estar vacia")]
        [RegularExpression(@"^[0-9]{11,13}$", ErrorMessage = "Digite un Numero de Cedula Valido")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = " El Telefono no puede estar vacio")]
        [RegularExpression(@"^[0-9]{10,10}$",ErrorMessage = "Digite un Numero de telefono Valido")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Direccion no puede estar vacia")]
        public string Direccion { get; set; } 
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío")]
        public DateTime Fecha { get; set; }
        [MinLength(1, ErrorMessage = "Debe seleccionar un tipo de cliente")]
        public int TipoClienteId { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            Fecha = DateTime.Now;
            TipoClienteId = 0;
        }
    }
}
