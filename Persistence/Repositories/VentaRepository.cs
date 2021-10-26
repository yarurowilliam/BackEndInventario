using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
    public class VentaRepository:IVentaRepository
    {
        private readonly AplicationDbContext _context;
        public VentaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateVenta(Venta venta)
        {
            _context.Add(venta);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Venta>> GetListVentas()
        {
            var listVentas = await _context.Ventas.Where(x => x.Id != 0).ToListAsync();
            return listVentas;
        }

        public async Task<Venta> GetVenta(int id)
        {
            var venta = await _context.Ventas.Where(x => x.Id == id)
                                                    .Include(x => x.listDetalleVentas)
                                                    .FirstOrDefaultAsync();
            return venta;
        }
    }
}
