using BackEnd.Domain.IServices;
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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody] Categoria categoria)
        {
            try
            {
                var validateExistence = await _categoriaService.ValidateExistence(categoria);
                if (validateExistence)
                {
                    return BadRequest(new { message = "la categoria " + categoria.NombreCategoria + " ya existe! " });
                }
                await _categoriaService.SavedCategoria(categoria);
                return Ok(new { message = "Categoria registrada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListCategorias")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListCategorias()
        {
            try
            {
                var listCategoria = await _categoriaService.GetListCategorias();
                return Ok(listCategoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var categoria = await _categoriaService.GetCategoria(id);
                return Ok(categoria);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var categoria = await _categoriaService.BuscarCategoria(id);
                if (categoria == null)
                {
                    return BadRequest(new { message = "No se encontro ninguna categoria" });
                }
                await _categoriaService.EliminarCategoria(categoria);
                return Ok(new { message = "La categoria fue eliminada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
