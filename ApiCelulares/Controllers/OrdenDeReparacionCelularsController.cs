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
using ApiCelulares.Excepciones;
using System.Security.Cryptography.X509Certificates;

namespace ApiCelulares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrdenDeReparacionCelularsController : ControllerBase
    {
        private LogicaOrdenReparacionCel iLogicaOrdenReparacionCel;

        public OrdenDeReparacionCelularsController(LogicaOrdenReparacionCel pLogicaOrdenReparacionCel)
        {
            iLogicaOrdenReparacionCel = pLogicaOrdenReparacionCel;
        }
        /// <summary>
        /// Listado de todas las orden reparacion celular
        /// </summary>
        /// <returns>Devuelve un listado de todos ordenes reparacion celular</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoOrdenDeReparacionCelular>>> GetOrdenReparacionCelularDTO()
        {
            try
            {
                return await iLogicaOrdenReparacionCel.ObtenerOrdenReparacionCelular();
            }
            catch (OrdenReparacionCelularNoEncontrada msg)
            {
                return NotFound(msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }

        /// <summary>
        /// Obtiene una orden reparacion celular
        /// </summary>
        /// <param name="id">busca por id de orden reparacion</param>
        /// <returns>Devuelve una reparacion</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DtoOrdenDeReparacionCelular>> GetOrdenReparacionCelularDTO(int id)
        {
            try
            {
                return await iLogicaOrdenReparacionCel.ObtenerUnaOrdenReparacionCelular(id);
            }
            catch (OrdenReparacionCelularNoEncontrada msg)
            {
                return NotFound(msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }
        /// <summary>
        /// Modificar una orden reparacion celular
        /// </summary>
        /// <param name="OrdenReparacionDTO"></param>
        /// <returns>reparacion Modificado</returns>
        [HttpPut]
        public async Task<IActionResult> PutOrdenReparacionCelularDTO(DtoOrdenDeReparacionCelular OrdenReparacionDTO)
        {
            try
            {
                await iLogicaOrdenReparacionCel.ModificarOrdenReparacionCelular(OrdenReparacionDTO);
                return Ok("Se modificó Orden Reparacion Celular");
            }
            catch (ClienteNoEncontrado msg)
            {
                return StatusCode(412, msg.Message);
            }
            catch (OrdenReparacionCelularNoEncontrada msg)
            {
                return NotFound(msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }
        /// <summary>
        /// Agregar orden reparacion celular
        /// </summary>
        /// <param name="pOrdenReparacionCelular"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostOrdenReparacionDTO(DtoOrdenDeReparacionCelular pOrdenReparacionCelular)
        {
            try
            {
                await iLogicaOrdenReparacionCel.AgregarOrdenReparacionCelular(pOrdenReparacionCelular);
                return Ok("Se registró Orden Reparacion Celular");
            }
            catch (ClienteNoEncontrado msg)
            {
                return StatusCode(412, msg.Message);
            }
            catch (OrdenReparacionCelularExistente msg)
            {
                return StatusCode(412, msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }
        /// <summary>
        /// Elimina una orden reparacion celular de la base de datos
        /// </summary>
        /// <param name="id">Id del orden reparacion celular a eliminar</param>
        /// <returns>orden eliminado</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrdenReparacionCelularDTO(int id)
        {
            try
            {
                await iLogicaOrdenReparacionCel.EliminarOrdenReparacionCelularDTO(id);
                return Ok("Se elimino Orden Reparacion Celular");
            }
            catch (OrdenReparacionCelularNoEncontrada msg)
            {
                return NotFound(msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }
        /// <summary>
        /// Obtengo todos las orden de reparacion de un cliente por dni
        /// </summary>
        /// <param name="pDni"></param>
        /// <returns>listado orden de reparaciones cel</returns>
        [HttpGet("GetTodasOrdenReparacionCelular/{pDni}")]
        public async Task<ActionResult<IEnumerable<DtoOrdenDeReparacionCelular>>> GetTodasOrdenReparacionCelular(string pDni)
        {
            try
            {
                return await iLogicaOrdenReparacionCel.TodosLasOrdenesReparacionCelularPorDni(pDni);
            }
            catch (ClienteNoEncontrado msg)
            {
                return NotFound(msg.Message);
            }
            catch (OrdenReparacionCelularNoEncontrada msg)
            {
                return NotFound(msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }
        /// <summary>
        /// Actualiza el estado de una orden reparacion
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pEstado"></param>
        /// <returns>estado Atualizado</returns>
        [HttpPut("ActualizarEstadoOrden/{pId}")]
        public async Task<IActionResult> ActualizarEstadoOrden(int pId, string pEstado)
        {
            try
            {
                await iLogicaOrdenReparacionCel.ModificarEstadoOrden(pId, pEstado);
                return Ok("Se Actualizo Estado de la Orden Reparación");
            }
            catch (OrdenReparacionCelularNoEncontrada msg)
            {
                return StatusCode(412, msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }

        /// <summary>
        /// obtiene id
        /// </summary>
        /// <returns></returns>
        //[HttpGet("UltimoIdReparacionPc")]
        //public async Task<ActionResult<int>> UltimoIdReparacionPc()
        //{
        //    try
        //    {
        //        return await iLogicaOrdenReparacionCel.ObtenerUltimoIdReparacionCel();
        //    }
        //    catch (OrdenReparacionCelularNoEncontrada msg)
        //    {
        //        return NotFound(msg.Message);
        //    }
        //    catch (Exception msg)
        //    {
        //        return StatusCode(500, msg.Message);
        //    }
        //}
        [HttpGet("UltimoIdReparacionPc")]
        public ActionResult<int> UltimoIdReparacionPc()
        {
            try
            {
                return iLogicaOrdenReparacionCel.ObtenerUltimoIdReparacionCel();
            }
            catch (OrdenReparacionCelularNoEncontrada msg)
            {
                return NotFound(msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }
        [HttpGet("GetOrdenReparacionCelDTOPage")]
        public async Task<ActionResult<IEnumerable<DtoOrdenDeReparacionCelular>>> GetOrdenReparacionCelDTOPage(int pnumber, int psize)
        {
            try
            {
                return await iLogicaOrdenReparacionCel.ObtenerOrdenReparacionCelPage(pnumber, psize);
            }
            catch (OrdenReparacionCelularNoEncontrada msg)
            {
                return NotFound(msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }
    }
}
