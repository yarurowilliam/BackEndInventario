using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class ArticuloFiltro
    {
        public string Referencia { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public string Categoria { get; set; }
        public string Proveedor { get; set; }
        public string EstadoCompra { get; set; }
        public double PrecioFinalCompra { get; set; }
        public string Comentarios { get; set; }





    }
}
