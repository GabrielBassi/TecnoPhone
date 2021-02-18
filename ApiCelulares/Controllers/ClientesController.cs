using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCelulares.Controllers.DTO;
using ApiCelulares.DAL;
using ApiCelulares.Controllers.Servicios.LogicaDelNegocio;
using AutoMapper;
using ApiCelulares.Excepciones;

namespace ApiCelulares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientesController : ControllerBase
    {
        private LogicaCliente iLogicaCliente;

        public ClientesController(LogicaCliente pLogicaCliente)
        {
            iLogicaCliente = pLogicaCliente;
        }

        /// <summary>
        /// Obtiene una lista de clientes
        /// </summary>
        /// <returns>Devuelve una lista de clientes</returns>
        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoCliente>>> GetDtoCliente()
        {
            try
            {
                return await iLogicaCliente.ObtenerClientesDTO();
            }
            catch (ClienteNoEncontrado msg)
            {
                return NotFound(msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }

        /// <summary>
        /// Obtiene un dni de un cliente
        /// </summary>
        /// <param name="pDni"></param>
        /// <returns>DEvuelve un dni de un cliente</returns>
        // GET: api/Clientes/5
        [HttpGet("{pDni}")]
        public async Task<ActionResult<DtoCliente>> GetDtoCliente(string pDni)
        {
            try
            {
                return await iLogicaCliente.ObtenerClienteDtoPorDni(pDni);
            }
            catch (ClienteNoEncontrado msg)
            {
                return NotFound(msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }

        /// <summary>
        /// Modifica un cliente
        /// </summary>
        /// <param name="pDtoCliente"></param>
        /// <returns>Cliente modificado</returns>
        [HttpPut]
        public async Task<IActionResult> PutDtoCliente(DtoCliente pDtoCliente)
        {
            try
            {
                await iLogicaCliente.ModificarCliente(pDtoCliente);
                return Ok("El cliente se modifico correctamente");
            }
            catch (ClienteNoEncontrado msg)
            {
                return StatusCode(412, msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }

        /// <summary>
        /// Agrega un nuevo cliente
        /// </summary>
        /// <param name="pClienteDto"></param>
        /// <returns>Cliente registrado</returns>
        [HttpPost]
        public async Task<ActionResult<DtoCliente>> PostDtoCliente(DtoCliente pClienteDto)
        {
            try
            {
                await iLogicaCliente.AgregarCliente(pClienteDto);
                return Ok("El cliente se registro con éxito");
            }
            catch (ClienteExistente msg)
            {
                return StatusCode(412, msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }

        /// <summary>
        /// Elimina un cliente 
        /// </summary>
        /// <param name="pDni"></param>
        /// <returns>Cliente eliminado</returns>
        [HttpDelete("{pDni}")]
        public async Task<ActionResult<DtoCliente>> DeleteDtoCliente(string pDni)
        {
            try
            {
                await iLogicaCliente.EliminarClienteDTO(pDni);
                return Ok("Se elimino el cliente con éxito");
            }
            catch (ClienteNoEncontrado msg)
            {
                return NotFound(msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }

        //private bool DtoClienteExists(int id)
        //{
        //   // return _context.DtoCliente.Any(e => e.DtoClienteId == id);
        //}
    }
}
