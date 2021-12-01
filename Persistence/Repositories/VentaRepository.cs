﻿using BackEnd.Domain.IRepositories;
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
        
        public string GetMejorCliente()
        {
            string identi = "";
            var query = from liq in _context.Ventas
                        group liq by liq.ClienteId into g
                        select new VentaPrueba
                        {
                            ClienteId = g.Key,
                            TotalPagar = g.Sum(x => x.TotalPagar)
                        };
            var result = query.Max(x => x.TotalPagar );
            foreach (var prueba in query)
            {
                if (result == prueba.TotalPagar)
                {
                    identi = prueba.ClienteId;
                }
            }
            return identi;
        }

        public async Task<Venta> GetVenta(int id)
        {
            var venta = await _context.Ventas.Where(x => x.Id == id)
                                                    .Include(x => x.listDetalleVentas)
                                                    .FirstOrDefaultAsync();
            
            return venta;
        }

        public double TraerGanancias()
        {
            var totalGanancias = _context.Ventas.Where(x => x.Id != 0).Sum(x => x.TotalPagar);
            return totalGanancias;
        }

        public async Task UpdateVenta(Venta venta)
        {
            _context.Update(venta);
            await _context.SaveChangesAsync();
        }
    }
}
