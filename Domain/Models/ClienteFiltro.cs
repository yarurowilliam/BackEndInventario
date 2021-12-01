using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class ClienteFiltro
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public double TotalPagado { get; set; }
    }
}
