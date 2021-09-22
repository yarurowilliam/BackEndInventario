using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class Articulo
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string Referencia { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public double Precio { get; set; }

        public int CategoriaId { get; set; }
        public Categoria categoria { get; set; }
        public string ProveedorNit { get; set; }
        public Proveedor proveedor { get; set; }




    }
}
