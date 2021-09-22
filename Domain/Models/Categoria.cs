using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(40)")]
        public string NombreCategoria { get; set; }
    }
}
