﻿using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public async Task CreateProveedor(Proveedor proveedor)
        {
            await _proveedorRepository.CreateProveedor(proveedor);
        }

        public async Task<List<Proveedor>> GetListProveedores()
        {
            return await _proveedorRepository.GetListProveedores();
        }

        public async Task<List<Proveedor>> GetListProveedoresFiltrada(string nit)
        {
            return await _proveedorRepository.GetListProveedoresFiltrada(nit);
        }
    }
}
