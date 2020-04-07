using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Models
{
    public class Usuarios
    {
        [Key]
        [Required(ErrorMessage = "Usuario no puede estar vacio")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = " Nombre no puede estar vacío")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Email es obligatorio")]
        [EmailAddress(ErrorMessage = "Debe ingresar un Email valido.")]
        [MaxLength(40, ErrorMessage = "Este correo es muy largo.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El Usuario no puede estar vacío")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "La Contraseña no puede estar vacío")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
        [Required(ErrorMessage = "Vuelva a escribir la contraseña")]
        [Compare("Contraseña", ErrorMessage = "La Contraseña y la confirmacion no coinciden.")]
        public string RepeatContraseña { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío")]
        public DateTime Fecha { get; set; }
        [Range(minimum: 1, maximum: 999999999999, ErrorMessage = "Debe seleccionar un Tipo de Usuario .")]
        public int TipoUsuarioId { get; set; }
        public Usuarios()
        {
            UsuarioId = 0;
            Nombre = string.Empty;
            Email = string.Empty;
            Usuario = string.Empty;
            Contraseña = string.Empty;
            RepeatContraseña = string.Empty;
            Fecha = DateTime.Now;
            TipoUsuarioId = 0;
        }
    }
}
