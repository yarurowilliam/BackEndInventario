using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface IDetalleVentaService
    {
        Task<ArticuloVendidoModel> TraerPrueba();
        Task<ArticuloVendidoModel> MenosVendido();
        string ArticuloMasVendido();
    }
}
