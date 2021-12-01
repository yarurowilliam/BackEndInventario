
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
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private readonly IDetalleVentaService _ventaService;

        public DetalleVentaController(IDetalleVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [Route("ArticuloMasVendido")]
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var venta = await _ventaService.TraerPrueba();
                return Ok(venta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("ArticuloMenosVendido")]
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetMenos()
        {
            try
            {
                var venta = await _ventaService.MenosVendido();
                return Ok(venta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
