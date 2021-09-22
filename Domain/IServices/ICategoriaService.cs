﻿using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface ICategoriaService
    {
        Task SavedCategoria(Categoria categoria);
        Task<bool> ValidateExistence(Categoria categoria);
        Task<List<Categoria>> GetListCategorias();
        Task<Categoria> GetCategoria(int id);
        Task<Categoria> BuscarCategoria(int id);
        Task EliminarCategoria(Categoria categoria);
    }
}
