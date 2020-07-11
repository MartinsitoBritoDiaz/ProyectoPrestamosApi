using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPrestamosApi.Models
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el nombre")]
        public string Nombre { get; set; }

        [Phone(ErrorMessage = "Solo debe introducir numeros")]
        [Required(ErrorMessage = "Es obligatorio introducir el telefono")]
        [StringLength(10, ErrorMessage = "Debe contener 10 digitos", MinimumLength = 10)]
        public string Telefono { get; set; }

        [Phone(ErrorMessage = "Solo debe introducir numeros")]
        [Required(ErrorMessage = "Es obligatorio introducir la cedula")]
        [StringLength(11, ErrorMessage = "Debe contener 11 digitos", MinimumLength = 11)]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la direccion")]
        public string Direccion { get; set; }

        public double Balance { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }
    }
}
