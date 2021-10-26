
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
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }


        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody]Venta venta)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);
                venta.UsuarioId = idUsuario;
                venta.EstadoVenta = "VIGENTE";
                venta.Fecha = DateTime.Now;
                await _ventaService.CreateVenta(venta);
                return Ok(new { message = "La venta se registro en el sistema"});
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListVentas")]
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListVentas()
        {
            try
            {
                var listVenta = await _ventaService.GetListVentas();
                return Ok(listVenta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var venta = await _ventaService.GetVenta(id);
                return Ok(venta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
