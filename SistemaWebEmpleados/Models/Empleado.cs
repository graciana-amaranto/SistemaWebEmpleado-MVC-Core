using SistemaWebEmpleados.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaWebEmpleados.Models
{
    [Table("Empleado")]
    public class Empleado
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Apellido { get; set; }

        [Required]
        public int DNI { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        [RegularExpression("[A]{2}[0-9]{5}")]
        public string Legajo { get; set; }

        [MayorQue]
        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Titulo { get; set; }
    }
}
