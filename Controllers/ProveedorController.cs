﻿using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using BackEnd.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody] Proveedor proveedor)
        {
            try
            {
                await _proveedorService.CreateProveedor(proveedor);
                return Ok(new { message = "Proveedor agregado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListProveedores")]
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListProveedores()
        {
            try
            {
                var listProveedor = await _proveedorService.GetListProveedores();
                return Ok(listProveedor);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListProveedoresFiltrada")]
        [HttpGet("{nit}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListProveedoresFiltrada(string nit)
        {
            try
            {
                var listProveedor = await _proveedorService.GetListProveedoresFiltrada(nit);
                return Ok(listProveedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
