﻿using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                await _clienteService.CreateCliente(cliente);
                return Ok(new { message = "Cliente agregado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListClientes")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListClientes()
        {
            try
            {
                var listCliente = await _clienteService.GetListClientes();
                return Ok(listCliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListClientesFiltrada")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListClientesFiltrada(string identificacion)
        {
            try
            {
                var listCliente = await _clienteService.GetListClientesFiltrada(identificacion);
                return Ok(listCliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{identificacion}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(string identificacion)
        {
            try
            {
                var cliente = await _clienteService.GetCliente(identificacion);
                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{identificacion}")]
        public async Task<IActionResult> PutCliente(string identificacion, Cliente item)
        {
            if (identificacion != item.Identificacion)
            {
                return BadRequest(new { message = "Usuario no encontrado" });
            }
            await _clienteService.UpdateCliente(item);
            return Ok(new { message = "El cliente fue modificado" });
        }
    }
}
