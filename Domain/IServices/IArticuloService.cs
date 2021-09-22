using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface IArticuloService
    {
        Task SavedArticulo(Articulo articulo);
        Task<List<Articulo>> GetListArticulos();
        Task<Articulo> GetArticulo(string referencia);
        Task<Articulo> BuscarArticulo(string referencia);
        Task EliminarArticulo(Articulo articulo);
    }
}
