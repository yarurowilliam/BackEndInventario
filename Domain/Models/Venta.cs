    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class Venta
    {
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public double TotalPagar { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string EstadoVenta { get; set; }

        public string ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public List<DetalleVenta> listDetalleVentas { get; set; }
    }
}
