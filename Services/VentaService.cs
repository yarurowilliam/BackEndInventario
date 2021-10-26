using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class VentaService: IVentaService
    {
        private readonly IVentaRepository _ventaRepository;
        public VentaService(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public async Task CreateVenta(Venta venta)
        {
            await _ventaRepository.CreateVenta(venta);
        }

        public async Task<List<Venta>> GetListVentas()
        {
            return await _ventaRepository.GetListVentas();
        }

        public async Task<Venta> GetVenta(int id)
        {
            return await _ventaRepository.GetVenta(id);
        }
    }
}
