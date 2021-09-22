using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class Proveedor
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string Nit { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string RazonSocial { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Direccion { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string NombreEnc { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Telefono { get; set; }
        [Required][EmailAddress]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
    }
}
