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
    public class DetalleVentaRepository : IDetalleVentaRepository
    {
        private readonly AplicationDbContext _context;
        public DetalleVentaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public string ArticuloMasVendido()
        {
            string identi = "";
            var query = from liq in _context.DetalleVentas
                        group liq by liq.Nombre into g
                        select new ArticuloVendidoModel
                        {
                            NombreProducto = g.Key,
                            TotalVendido = g.Sum(x => x.Cantidad)
                        };
            var result = query.Max(x => x.TotalVendido);
            foreach (var prueba in query)
            {
                if (result == prueba.TotalVendido)
                {
                    identi = prueba.NombreProducto;
                }
            }
            return identi;
        }


        public async Task<CategoriaVendida> MejorCategoria()
        {
            var guardarId = "";
            var query1 = from liq in _context.DetalleVentas
                        group liq by liq.Referencia into g
                        select new ArticuloVendidoModel
                        {
                            NombreProducto = g.Key,
                            TotalVendido = g.Sum(x => x.Cantidad)
                        };
            var query = from a in query1
                        join s in _context.Articulos on a.NombreProducto equals s.Referencia
                        join c in _context.Categorias on s.CategoriaId equals c.Id
                        select new CategoriaVendida
                        {
                            NombreCategoria = c.NombreCategoria,
                            TotalVendido = a.TotalVendido
                        };

            var result = query.Max(x => x.TotalVendido);
            foreach (var prueba in query)
            {
                if (result == prueba.TotalVendido)
                {
                    guardarId = prueba.NombreCategoria;
                }
            }
            var venta = await query.Where(x => x.NombreCategoria == guardarId).FirstOrDefaultAsync();

            return venta;
        }

        public async Task<ArticuloVendidoModel> MenosVendido()
        {
            var guardarId = "";
            var query = from liq in _context.DetalleVentas
                        group liq by liq.Nombre into g
                        select new ArticuloVendidoModel
                        {
                            NombreProducto = g.Key,
                            TotalVendido = g.Sum(x => x.Cantidad)
                        };
            var result = query.Min(x => x.TotalVendido);
            foreach (var prueba in query)
            {
                if (result == prueba.TotalVendido)
                {
                    guardarId = prueba.NombreProducto;
                }
            }
            var venta = await query.Where(x => x.NombreProducto == guardarId).FirstOrDefaultAsync();

            return venta;
        }

        public async Task<ArticuloVendidoModel> TraerPrueba()
        {
            var guardarId = "";
            var query = from liq in _context.DetalleVentas
                        group liq by liq.Nombre into g
                        select new ArticuloVendidoModel
                        {
                            NombreProducto = g.Key,
                            TotalVendido = g.Sum(x => x.Cantidad)
                        };
            var result = query.Max(x => x.TotalVendido);
            foreach (var prueba in query)
            {
                if (result == prueba.TotalVendido)
                {
                    guardarId = prueba.NombreProducto;
                }
            }
            var venta = await query.Where(x => x.NombreProducto == guardarId).FirstOrDefaultAsync();

            return venta;
        }
    }
}
