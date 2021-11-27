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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AplicationDbContext _context;

        public CategoriaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async  Task<Categoria> BuscarCategoria(int id)
        {
            var categoria = await _context.Categorias.Where(x => x.Id == id).FirstOrDefaultAsync();
            return categoria;
        }

        public async Task EliminarCategoria(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            var categoria = await _context.Categorias.Where(x => x.Id == id).FirstOrDefaultAsync();
            return categoria;
        }

        public async Task<List<Categoria>> GetListCategorias()
        {
            var listCategoria = await _context.Categorias.Where(x => x.Id != 0).ToListAsync();
            return listCategoria;
        }

        public async Task SavedCategoria(Categoria categoria)
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoria(Categoria categoria)
        {

                _context.Update(categoria);
                await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Categoria categoria)
        {
            var validateExistence = await _context.Categorias.AnyAsync(x => x.NombreCategoria == categoria.NombreCategoria);
            return validateExistence;
        }
    }
}
