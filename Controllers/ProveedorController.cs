using BackEnd.Domain.IServices;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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


        [HttpGet("{nit}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(string nit)
        {
            try
            {
                var proveedor = await _proveedorService.GetProveedor(nit);
                return Ok(proveedor);
            }catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{nit}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(string nit)
        {
            try
            {
                var proveedor = await _proveedorService.BuscarProveedor(nit);
                if (proveedor == null)
                {
                    return BadRequest(new { message = "No se encontro ningun proveedor" });
                }
                await _proveedorService.EliminarProveedor(proveedor);
                return Ok(new { message = "El proveedor fue eliminado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{nit}")]
        public async Task<IActionResult> UpdateProveedor(string nit, Proveedor item)
        {
            if (nit != item.Nit)
            {
                return BadRequest(new { message = "Proveedor no encontrado" });
            }
            await _proveedorService.UpdateProveedor(item);
            return Ok(new { message = "Listo!" });
        }
    }
}
