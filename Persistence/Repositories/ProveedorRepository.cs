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
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly AplicationDbContext _context;
        public ProveedorRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Proveedor> BuscarProveedor(string nit)
        {
            var proveedor = await _context.Proveedores.Where(x => x.Nit == nit).FirstOrDefaultAsync();
            return proveedor;
        }

        public async Task CreateProveedor(Proveedor proveedor)
        {
            _context.Add(proveedor);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarProveedor(Proveedor proveedor)
        {
            _context.Proveedores.Remove(proveedor);
            //_context.Entry(proveedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Proveedor>> GetListProveedores()
        {
            var listProveedores = await _context.Proveedores.Where(x => x.Nit != null).ToListAsync();
            return listProveedores;
        }

        public async Task<List<Proveedor>> GetListProveedoresFiltrada(string nit)
        {
            var listProveedores = await _context.Proveedores.Where(x => x.Nit == nit).ToListAsync();
            return listProveedores;
        }

        public async Task<Proveedor> GetProveedor(string nit)
        {
            var proveedor = await _context.Proveedores.Where(x => x.Nit == nit).FirstOrDefaultAsync();
            return proveedor;
        }

        public async Task UpdateProveedor(Proveedor proveedor)
        {
            _context.Update(proveedor);
            await _context.SaveChangesAsync();
        }
    }
}
