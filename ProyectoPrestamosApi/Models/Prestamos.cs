using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPrestamosApi.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la fecha del prestamo")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el concepto")]
        public string Concepto { get; set; }

        [Range(1,10000000000000, ErrorMessage ="Debe de ingresar un monto valido!!")]
        [Required(ErrorMessage = "Es obligatorio introducir el monto")]
        public double Monto { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el balance")]
        public double Balance { get; set; }
        public int PersonaId { get; set; }
    }
}
