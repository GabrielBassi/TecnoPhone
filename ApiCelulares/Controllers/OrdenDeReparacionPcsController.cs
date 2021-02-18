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

namespace ApiCelulares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrdenDeReparacionPcsController : ControllerBase
    {
        private LogicaOrdenReparacionPc iLogicaOrdenReparacionPc;

        public OrdenDeReparacionPcsController(LogicaOrdenReparacionPc pLogicaOrdenReparacionPc)
        {
            iLogicaOrdenReparacionPc = pLogicaOrdenReparacionPc;
        }
        /// <summary>
        /// Listado de todas las ordenes de reparacion de las pc
        /// </summary>
        /// <returns>Devuelve un listado de todas las ordenes de reparacion de las pc</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoOrdenDeReparacionPc>>> GetOrdenReparacionPcDTO()
        {
            try
            {
                return await iLogicaOrdenReparacionPc.ObtenerOrdenReparacionPc();
            }
            catch (OrdenReparacionPcNoEncontrada msg)
            {
                return NotFound(msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }

        /// <summary>
        /// Obtiene una orden reparacion de una pc
        /// </summary>
        /// <param name="id">Busca por id de orden reparacion</param>
        /// <returns>Devuelve una reparacion pc</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DtoOrdenDeReparacionPc>> GetOrdenReparacionPcDTO(int id)
        {
            try
            {
                return await iLogicaOrdenReparacionPc.ObtenerUnaOrdenReparacionPc(id);
            }
            catch (OrdenReparacionPcNoEncontrada msg)
            {
                return NotFound(msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }

        /// <summary>
        /// Modificar una orden reparacion pc
        /// </summary>
        /// <param name="OrdenReparacionDTO"></param>
        /// <returns>reparacion Modificado</returns>
        [HttpPut]
        public async Task<IActionResult> PutOrdenReparacionPcDTO(DtoOrdenDeReparacionPc OrdenReparacionDTO)
        {
            try
            {
                await iLogicaOrdenReparacionPc.ModificarOrdenReparacionPc(OrdenReparacionDTO);
                return Ok("Se modificó Orden Reparacion Pc");
            }
            catch (ClienteNoEncontrado msg)
            {
                return StatusCode(412, msg.Message);
            }
            catch (OrdenReparacionPcNoEncontrada msg)
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
        /// <param name="pOrdenReparacionPc"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostOrdenReparacionDTO(DtoOrdenDeReparacionPc pOrdenReparacionPc)
        {
            try
            {
                await iLogicaOrdenReparacionPc.AgregarOrdenReparacionPc(pOrdenReparacionPc);
                return Ok("Se registró Orden Reparacion Pc");
            }
            catch (ClienteNoEncontrado msg)
            {
                return StatusCode(412, msg.Message);
            }
            catch (OrdenReparacionPcExistente msg)
            {
                return StatusCode(412, msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }

        /// <summary>
        /// Elimina una orden reparacion pc de la base de datos
        /// </summary>
        /// <param name="id">Id del orden reparacion pc a eliminar</param>
        /// <returns>reparacion eliminado</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrdenReparacionPcDTO(int id)
        {
            try
            {
                await iLogicaOrdenReparacionPc.EliminarOrdenReparacionPcDTO(id);
                return Ok("Se elimino Orden Reparacion Pc");
            }
            catch (OrdenReparacionPcNoEncontrada msg)
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
        /// <returns>listado orden de reparaciones pc</returns>
        [HttpGet("GetTodasOrdenReparacionPc/{pDni}")]
        public async Task<ActionResult<IEnumerable<DtoOrdenDeReparacionPc>>> GetTodasOrdenReparacionPc(string pDni)
        {
            try
            {
                return await iLogicaOrdenReparacionPc.TodosLasOrdenesReparacionPcPorDni(pDni);
            }
            catch (ClienteNoEncontrado msg)
            {
                return NotFound(msg.Message);
            }
            catch (OrdenReparacionPcNoEncontrada msg)
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
        /// <returns>Estado Atualizado</returns>
        [HttpPut("ActualizarEstadoOrden/{pId}")]
        public async Task<IActionResult> ActualizarEstadoOrden(int pId, string pEstado)
        {
            try
            {
                await iLogicaOrdenReparacionPc.ModificarEstadoOrden(pId, pEstado);
                return Ok("Se Actualizo Estado de la Orden Reparación");
            }
            catch (OrdenReparacionPcNoEncontrada msg)
            {
                return StatusCode(412, msg.Message);
            }
            catch (Exception msg)
            {
                return StatusCode(500, msg.Message);
            }
        }
        ///// <summary>
        ///// obtiene id
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("UltimoIdReparacionPc")]
        //public async Task<ActionResult<int>> UltimoIdReparacionPc()
        //{
        //    try
        //    {
        //        return await iLogicaOrdenReparacionPc.ObtenerUltimoIdReparacionPc();
        //    }
        //    catch (OrdenReparacionPcNoEncontrada msg)
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
                return iLogicaOrdenReparacionPc.ObtenerUltimoIdReparacionPc();
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
        /// 
        /// </summary>
        /// <param name="pnumber"></param>
        /// <param name="psize"></param>
        /// <returns></returns>
        [HttpGet("GetOrdenReparacionPcDTOPage")]
        public async Task<ActionResult<IEnumerable<DtoOrdenDeReparacionPc>>> GetOrdenReparacionPcDTOPage(int pnumber, int psize)
        {
            try
            {
                ////var ss = iLogicaOrdenReparacionPc.ObtenerOrdenReparacionPcPage()
                //var metadata = new
                //{

                //}
                //Response.Headers.Add("X-Pagination",)
                return await iLogicaOrdenReparacionPc.ObtenerOrdenReparacionPcPage(pnumber, psize);
            }
            catch (OrdenReparacionPcNoEncontrada msg)
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
