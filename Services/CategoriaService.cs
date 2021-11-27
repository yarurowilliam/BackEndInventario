using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class CategoriaService : ICategoriaService
    {

        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }


        public async Task<Categoria> BuscarCategoria(int id)
        {
            return await _categoriaRepository.BuscarCategoria(id);
        }

        public async Task EliminarCategoria(Categoria categoria)
        {
            await _categoriaRepository.EliminarCategoria(categoria);
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            return await _categoriaRepository.GetCategoria(id);
        }

        public async Task<List<Categoria>> GetListCategorias()
        {
            return await _categoriaRepository.GetListCategorias();
        }

        public async Task SavedCategoria(Categoria categoria)
        {
            await _categoriaRepository.SavedCategoria(categoria);
        }

        public async Task UpdateCategoria(Categoria categoria)
        {
            await _categoriaRepository.UpdateCategoria(categoria);
        }

        public async Task<bool> ValidateExistence(Categoria categoria)
        {
            return await _categoriaRepository.ValidateExistence(categoria);
        }
    }
}
