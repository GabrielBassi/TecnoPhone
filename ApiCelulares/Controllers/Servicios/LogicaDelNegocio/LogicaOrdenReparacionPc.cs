using ApiCelulares.Controllers.DTO;
using ApiCelulares.DAL;
using ApiCelulares.Excepciones;
using ApiCelulares.Modelo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Controllers.Servicios.LogicaDelNegocio
{
    public class LogicaOrdenReparacionPc
    {
        private readonly IUnidadDeTrabajo iUdt;
        private readonly IMapper iMapper;
        public LogicaOrdenReparacionPc(IUnidadDeTrabajo pUdt, IMapper pMapper)
        {
            iUdt = pUdt;
            iMapper = pMapper;
        }
        public async Task<ActionResult<IEnumerable<DtoOrdenDeReparacionPc>>> ObtenerOrdenReparacionPc()
        {
            IEnumerable<OrdenDeReparacion> listaOrdenReparacion = await iUdt.RepositorioOrdenDeReparacion.ObtengoListaTodosLasPC();
            if (listaOrdenReparacion.Count() == 0)
            {
                throw new OrdenReparacionPcNoEncontrada("No se encontro listado de orden de reparación");
            }
          //  IList<DtoOrdenDeReparacionPc> listaOrdenRepaDTO = new List<DtoOrdenDeReparacionPc>();
            var listaOrdenRepaDTO = iMapper.Map<IList<DtoOrdenDeReparacionPc>>(listaOrdenReparacion);
            //foreach (OrdenDeReparacion item in listaOrdenReparacion)
            //{
            //    listaOrdenRepaDTO.Add(iMapper.Map<OrdenDeReparacion, DtoOrdenDeReparacionPc>(item));
            //}
            return listaOrdenRepaDTO.ToList();
        }

        public async Task<ActionResult<DtoOrdenDeReparacionPc>> ObtenerUnaOrdenReparacionPc(int pId)
        {
            var mOrdenRepa = await iUdt.RepositorioOrdenDeReparacion.Obtener(pId);
            if ((mOrdenRepa == null)||(mOrdenRepa.TipoEquipo.nombre=="Celular"))
            {
                throw new OrdenReparacionPcNoEncontrada("No se encontro Orden Reparación");
            }
            DtoOrdenDeReparacionPc mOrdenReparacionDTO = iMapper.Map<OrdenDeReparacion, DtoOrdenDeReparacionPc>(mOrdenRepa);
            return mOrdenReparacionDTO;
        }

        public async Task ModificarOrdenReparacionPc(DtoOrdenDeReparacionPc ordenReparacionDTO)
        {
            bool existencia = iUdt.RepositorioOrdenDeReparacion.ConsultarExistenciaPc(ordenReparacionDTO.DtoOrdenDeReparacionPcId);
            if (existencia == false)
            {
                throw new OrdenReparacionPcNoEncontrada("No se encontro Orden de Reparación");
            }
            bool existenciaCliente = iUdt.RepositorioCliente.ConsultarExistencia(ordenReparacionDTO.dni);
            if (existenciaCliente == false)
            {
                throw new ClienteNoEncontrado("No se encontro Dni Cliente");
            }
            var mOrdenRepaMod = await iUdt.RepositorioOrdenDeReparacion.Obtener(ordenReparacionDTO.DtoOrdenDeReparacionPcId);
            mOrdenRepaMod.Cliente = await iUdt.RepositorioCliente.ObtenerClientePorDni(ordenReparacionDTO.dni);
            mOrdenRepaMod.fechaIngreso = ordenReparacionDTO.fechaIngreso;
            mOrdenRepaMod.fechaEgreso = ordenReparacionDTO.fecheEgreso;
            mOrdenRepaMod.detalle = ordenReparacionDTO.detalleOrden;
            mOrdenRepaMod.precio = ordenReparacionDTO.precio;
            mOrdenRepaMod.TipoEquipo.Pc.diagnostico = ordenReparacionDTO.diagnosticoPc;
            mOrdenRepaMod.TipoEquipo.Pc.ModeloPc.nombre = ordenReparacionDTO.nombreModeloPc;
            mOrdenRepaMod.TipoEquipo.Pc.ModeloPc.version = ordenReparacionDTO.versionPc;
            mOrdenRepaMod.TipoEquipo.Pc.ModeloPc.MarcaPc.nombre = ordenReparacionDTO.nombreMarcaPc;
            mOrdenRepaMod.estadoReparacion = ordenReparacionDTO.estado;
            mOrdenRepaMod.detalleReparacion = ordenReparacionDTO.detalleReparacion;
            mOrdenRepaMod.presupuesto = ordenReparacionDTO.presupuesto;
            mOrdenRepaMod.seña = ordenReparacionDTO.seña;
            mOrdenRepaMod.proveedor = ordenReparacionDTO.proveedor;
            mOrdenRepaMod.costoRepuesto = ordenReparacionDTO.costoRepuesto;

            iUdt.RepositorioOrdenDeReparacion.ModificarEntidades(mOrdenRepaMod);
            await iUdt.Guardar();
        }

        public async Task AgregarOrdenReparacionPc(DtoOrdenDeReparacionPc pOrdenPc)
        {
            var mOrden = await iUdt.RepositorioOrdenDeReparacion.Obtener(pOrdenPc.DtoOrdenDeReparacionPcId);
            if (mOrden == null)
            {
                Cliente iCliente = await iUdt.RepositorioCliente.ObtenerClientePorDni(pOrdenPc.dni);
                if (iCliente == null)
                {
                    throw new ClienteNoEncontrado("No se encontro Cliente");
                }
                OrdenDeReparacion iOrdenRepaPc = new OrdenDeReparacion
                {   costoRepuesto= pOrdenPc.costoRepuesto,
                    presupuesto = pOrdenPc.presupuesto,
                    seña = pOrdenPc.seña,
                    proveedor = pOrdenPc.proveedor,
                    fechaIngreso = pOrdenPc.fechaIngreso,
                    Cliente = iCliente,
                    detalle = pOrdenPc.detalleOrden,
                    estadoReparacion = pOrdenPc.estado,
                    detalleReparacion = pOrdenPc.detalleReparacion,
                    precio = pOrdenPc.precio,
                    TipoEquipo = new TipoEquipo
                    {
                        nombre = "Pc",
                        Pc = new Pc
                        {
                            diagnostico = pOrdenPc.diagnosticoPc,
                            ModeloPc=new ModeloPc
                            {
                                nombre=pOrdenPc.nombreModeloPc,
                                version=pOrdenPc.versionPc,
                                MarcaPc = new MarcaPc
                                {
                                    nombre=pOrdenPc.nombreMarcaPc
                                }
                            }
                        }
                    }
                };
                await iUdt.RepositorioOrdenDeReparacion.Agregar(iOrdenRepaPc);
                await iUdt.Guardar();
            }
            else
            {
                throw new OrdenReparacionPcExistente("La orden reparación ya se encuentra registrada");
            }
        }

        public async Task EliminarOrdenReparacionPcDTO(int pId)
        {
            var mOrdenRepaEliminar = await iUdt.RepositorioOrdenDeReparacion.Obtener(pId);
            if ((mOrdenRepaEliminar == null)||(mOrdenRepaEliminar.TipoEquipo.nombre=="Celular"))
            {
                throw new OrdenReparacionPcNoEncontrada("No se encontro Orden de Reparación");
            }
            iUdt.RepositorioOrdenDeReparacion.Eliminar(mOrdenRepaEliminar);
            iUdt.RepositorioTipoEquipo.Eliminar(mOrdenRepaEliminar.TipoEquipo);
            iUdt.RepositorioPc.Eliminar(mOrdenRepaEliminar.TipoEquipo.Pc);
            await iUdt.Guardar();
        }

        public async Task<ActionResult<IEnumerable<DtoOrdenDeReparacionPc>>> TodosLasOrdenesReparacionPcPorDni(string pDni)
        {
            bool existencia = iUdt.RepositorioCliente.ConsultarExistencia(pDni);
            if (existencia == false)
            {
                throw new ClienteNoEncontrado("No se encontro Dni del Cliente");
            }
            IEnumerable<OrdenDeReparacion> mListaOrdenRepaPc = await iUdt.RepositorioOrdenDeReparacion.ObtengoListaTodosLasOrdenesPcPorClienteDni(pDni);
            if (mListaOrdenRepaPc.Count() == 0)
            {
                throw new OrdenReparacionPcNoEncontrada("No se encontraron ordenes de reparaciones");
            }
            var listaOrdenRepaPcDTO = iMapper.Map<IList<DtoOrdenDeReparacionPc>>(mListaOrdenRepaPc);
            //IList<DtoOrdenDeReparacionPc> listaOrdenRepaPcDTO = new List<DtoOrdenDeReparacionPc>();
            //foreach (OrdenDeReparacion item in mListaOrdenRepaPc)
            //{
            //    listaOrdenRepaPcDTO.Add(iMapper.Map<OrdenDeReparacion, DtoOrdenDeReparacionPc>(item));
            //}
            return listaOrdenRepaPcDTO.ToList();
        }

        //public async Task<int> ObtenerUltimoIdReparacionPc()
        //{
        //   var mListaOrdenRepaPc = await iUdt.RepositorioOrdenDeReparacion.ObtenerUltimoId();
        //    if (mListaOrdenRepaPc == 0)
        //    {
        //        throw new OrdenReparacionPcNoEncontrada("No se encontraron ordenes de reparaciones");
        //    }
        //    return mListaOrdenRepaPc;
        //}
        public int ObtenerUltimoIdReparacionPc()
        {
            var mListaOrdenRepaPc =  iUdt.RepositorioOrdenDeReparacion.ObtenerUltimoId();
            if (mListaOrdenRepaPc == 0)
            {
                throw new OrdenReparacionPcNoEncontrada("No se encontraron ordenes de reparaciones");
            }
            return mListaOrdenRepaPc;
        }

        public async Task ModificarEstadoOrden(int pId, string pEstado)
        {
            var mOrdenRepaMod = await iUdt.RepositorioOrdenDeReparacion.Obtener(pId);
            if ((mOrdenRepaMod == null)||(mOrdenRepaMod.TipoEquipo.nombre=="Celular"))
            {
                throw new OrdenReparacionPcNoEncontrada("No se encontro Orden Reparación");
            }
            mOrdenRepaMod.estadoReparacion = pEstado;
            iUdt.RepositorioOrdenDeReparacion.ModificarEntidades(mOrdenRepaMod);
            await iUdt.Guardar();
        }
        public async Task<ActionResult<IEnumerable<DtoOrdenDeReparacionPc>>> ObtenerOrdenReparacionPcPage(int pid , int ppage)
        {
            IEnumerable<OrdenDeReparacion> listaOrdenReparacion = await iUdt.RepositorioOrdenDeReparacion.ObtengoListaTodosLasPC();
            if (listaOrdenReparacion.Count() == 0)
            {
                throw new OrdenReparacionPcNoEncontrada("No se encontro listado de orden de reparación");
            }
            var pagePost = Paginacion<OrdenDeReparacion>.CreateAsync(listaOrdenReparacion, pid, ppage);
            var listaOrdenRepaDTO = iMapper.Map<IEnumerable<DtoOrdenDeReparacionPc>>(pagePost);
           // Response.Headers.Add("X-Pagination",)
            return listaOrdenRepaDTO.ToList();
        }
    }
}


