using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface IProveedorService
    {
        Task CreateProveedor(Proveedor proveedor);
        Task<List<Proveedor>> GetListProveedores();
        Task<List<Proveedor>> GetListProveedoresFiltrada(string nit);
        Task<Proveedor> GetProveedor(string nit);
    }
}
