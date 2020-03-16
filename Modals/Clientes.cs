using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Modals
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = " Nombre no puede estar vacío")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = " Cedula no puede estar vacia")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = " El Telefono no puede estar vacio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Direccion no puede estar vacia")]
        public string Direccion { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío")]
        public DateTime FechaIngreso { get; set; }
        public Clientes()
        {
            ClienteId = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
        }
    }
}
