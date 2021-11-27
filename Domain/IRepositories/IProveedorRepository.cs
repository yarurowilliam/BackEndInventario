﻿using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IRepositories
{
    public interface IProveedorRepository
    {
        Task CreateProveedor(Proveedor proveedor);
        Task<List<Proveedor>> GetListProveedores();
        Task<List<Proveedor>> GetListProveedoresFiltrada(string nit);
        Task<Proveedor> GetProveedor(string nit);
        Task<Proveedor> BuscarProveedor(string nit);
        Task EliminarProveedor(Proveedor proveedor);
        Task UpdateProveedor(Proveedor proveedor);
    }
}
