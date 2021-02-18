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
    public class LogicaOrdenReparacionCel
    {
        private readonly IUnidadDeTrabajo iUdt;
        private readonly IMapper iMapper;
        public LogicaOrdenReparacionCel(IUnidadDeTrabajo pUdt, IMapper pMapper)
        {
            iUdt = pUdt;
            iMapper = pMapper;
        }

        public async Task<ActionResult<IEnumerable<DtoOrdenDeReparacionCelular>>> ObtenerOrdenReparacionCelular()
        {
            IEnumerable<OrdenDeReparacion> listaOrdenReparacion = await iUdt.RepositorioOrdenDeReparacion.ObtengoListaTodosLosCelulares();
            if (listaOrdenReparacion.Count() == 0)
            {
                throw new OrdenReparacionCelularNoEncontrada("No se encontro listado de orden de reparación");
            }
           // IList<DtoOrdenDeReparacionCelular> listaOrdenRepaDTO = new List<DtoOrdenDeReparacionCelular>();
            var listaOrdenRepaDTO = iMapper.Map<IList<DtoOrdenDeReparacionCelular>>(listaOrdenReparacion);
            //foreach (OrdenDeReparacion item in listaOrdenReparacion)
            //{
            //        listaOrdenRepaDTO.Add(iMapper.Map<OrdenDeReparacion, DtoOrdenDeReparacionCelular>(item));
            //}
            return listaOrdenRepaDTO.ToList();
        }

        public async Task<ActionResult<DtoOrdenDeReparacionCelular>> ObtenerUnaOrdenReparacionCelular(int pId)
        {
            var mOrdenRepa = await iUdt.RepositorioOrdenDeReparacion.Obtener(pId);
            if ((mOrdenRepa == null) || (mOrdenRepa.TipoEquipo.nombre=="Pc"))
            {
                throw new OrdenReparacionCelularNoEncontrada("No se encontro Orden Reparación");
            }
            DtoOrdenDeReparacionCelular mOrdenReparacionDTO = iMapper.Map<OrdenDeReparacion, DtoOrdenDeReparacionCelular>(mOrdenRepa);
            return mOrdenReparacionDTO;
        }

        public async Task ModificarOrdenReparacionCelular(DtoOrdenDeReparacionCelular ordenReparacionDTO)
        {
            bool existencia = iUdt.RepositorioOrdenDeReparacion.ConsultarExistenciaCelular(ordenReparacionDTO.DtoOrdenDeReparacionCelularId);
            if (existencia == false)
            {
                throw new OrdenReparacionCelularNoEncontrada("No se encontro Orden de Reparación");
            }
            bool existenciaCliente = iUdt.RepositorioCliente.ConsultarExistencia(ordenReparacionDTO.dni);
            if (existenciaCliente == false)
            {
                throw new ClienteNoEncontrado("No se encontro Dni Cliente");
            }
            var mOrdenRepaMod = await iUdt.RepositorioOrdenDeReparacion.Obtener(ordenReparacionDTO.DtoOrdenDeReparacionCelularId);
            mOrdenRepaMod.Cliente =await iUdt.RepositorioCliente.ObtenerClientePorDni(ordenReparacionDTO.dni);
            mOrdenRepaMod.detalle = ordenReparacionDTO.detalleOrden;
            mOrdenRepaMod.detalleReparacion = ordenReparacionDTO.detalleReparacion;
            mOrdenRepaMod.estadoReparacion = ordenReparacionDTO.estado;
            mOrdenRepaMod.fechaEgreso = ordenReparacionDTO.fecheEgreso;
            mOrdenRepaMod.fechaIngreso = ordenReparacionDTO.fechaIngreso;
            mOrdenRepaMod.precio = ordenReparacionDTO.precio;
            mOrdenRepaMod.TipoEquipo.Celular.chip = ordenReparacionDTO.chip;
            mOrdenRepaMod.TipoEquipo.Celular.diagnostico = ordenReparacionDTO.diagnosticoCelular;
            mOrdenRepaMod.TipoEquipo.Celular.empresa = ordenReparacionDTO.empresa;
            mOrdenRepaMod.TipoEquipo.Celular.enciende = ordenReparacionDTO.enciende;
            mOrdenRepaMod.TipoEquipo.Celular.ModeloCelular.version = ordenReparacionDTO.versionCelular;
            mOrdenRepaMod.TipoEquipo.Celular.ModeloCelular.nombre = ordenReparacionDTO.nombreModeloCelular;
            mOrdenRepaMod.TipoEquipo.Celular.ModeloCelular.MarcaCelular.nombre = ordenReparacionDTO.nombreMarcaCelular;
            mOrdenRepaMod.TipoEquipo.Celular.patron = ordenReparacionDTO.patron;
            mOrdenRepaMod.TipoEquipo.Celular.pin = ordenReparacionDTO.pin;
            mOrdenRepaMod.TipoEquipo.Celular.tarjetaSd = ordenReparacionDTO.tarjetaSD;
            mOrdenRepaMod.presupuesto = ordenReparacionDTO.presupuesto;
            mOrdenRepaMod.seña = ordenReparacionDTO.seña;
            mOrdenRepaMod.proveedor = ordenReparacionDTO.proveedor;
            mOrdenRepaMod.costoRepuesto = ordenReparacionDTO.costoRepuesto;
            iUdt.RepositorioOrdenDeReparacion.ModificarEntidades(mOrdenRepaMod);
            await iUdt.Guardar();
        }

        public async Task AgregarOrdenReparacionCelular(DtoOrdenDeReparacionCelular pOrdenCel)
        {
            var mOrden = await iUdt.RepositorioOrdenDeReparacion.Obtener(pOrdenCel.DtoOrdenDeReparacionCelularId);
            if (mOrden == null)
            {
                Cliente iCliente = await iUdt.RepositorioCliente.ObtenerClientePorDni(pOrdenCel.dni);
                if (iCliente == null)
                {
                    throw new ClienteNoEncontrado("No se encontro Cliente");
                }
                OrdenDeReparacion iOrdenRepaCel = new OrdenDeReparacion
                {
                    presupuesto= pOrdenCel.presupuesto,
                    seña = pOrdenCel.seña,
                    proveedor = pOrdenCel.proveedor,
                    costoRepuesto = pOrdenCel.costoRepuesto,
                    fechaIngreso = pOrdenCel.fechaIngreso,
                    fechaEgreso = pOrdenCel.fecheEgreso,
                    Cliente =iCliente,
                    detalle= pOrdenCel.detalleOrden,
                    estadoReparacion=pOrdenCel.estado,
                    detalleReparacion=pOrdenCel.detalleReparacion,
                    precio=pOrdenCel.precio,
                    TipoEquipo=new TipoEquipo
                    {
                        nombre="Celular",
                        Celular=new Celular
                        {
                            tarjetaSd= pOrdenCel.tarjetaSD,
                            chip= pOrdenCel.chip,
                            diagnostico= pOrdenCel.diagnosticoCelular,
                            empresa= pOrdenCel.empresa,
                            pin= pOrdenCel.pin,
                            enciende=pOrdenCel.enciende,
                            patron= pOrdenCel.patron,
                            ModeloCelular=new ModeloCelular
                            {
                                nombre= pOrdenCel.nombreModeloCelular,
                                version= pOrdenCel.versionCelular,
                                MarcaCelular=new MarcaCelular
                                {
                                    nombre= pOrdenCel.nombreMarcaCelular
                                }
                            }
                        }
                    }
                };
                await iUdt.RepositorioOrdenDeReparacion.Agregar(iOrdenRepaCel);
                await iUdt.Guardar();
            }
            else
            {
                throw new OrdenReparacionCelularExistente("La orden reparación ya se encuentra registrada");
            }
        }

        public async Task EliminarOrdenReparacionCelularDTO(int pId)
        {
            var mOrdenRepaEliminar = await iUdt.RepositorioOrdenDeReparacion.Obtener(pId);
            if (mOrdenRepaEliminar == null || (mOrdenRepaEliminar.TipoEquipo.nombre == "Pc"))
            {
                throw new OrdenReparacionCelularNoEncontrada("No se encontro Orden de Reparación");
            }
            iUdt.RepositorioOrdenDeReparacion.Eliminar(mOrdenRepaEliminar);
            iUdt.RepositorioTipoEquipo.Eliminar(mOrdenRepaEliminar.TipoEquipo);
            iUdt.RepositorioCelular.Eliminar(mOrdenRepaEliminar.TipoEquipo.Celular);
            await iUdt.Guardar();
        }

        public async Task<ActionResult<IEnumerable<DtoOrdenDeReparacionCelular>>> TodosLasOrdenesReparacionCelularPorDni(string pDni)
        {
            bool existencia = iUdt.RepositorioCliente.ConsultarExistencia(pDni);
            if (existencia == false)
            {
                throw new ClienteNoEncontrado("No se encontro Dni del Cliente");
            }
            IEnumerable<OrdenDeReparacion> mListaOrdenRepaCel = await iUdt.RepositorioOrdenDeReparacion.ObtengoListaTodosLasOrdenesCelularPorClienteDni(pDni);
            if (mListaOrdenRepaCel.Count() == 0)
            {
                throw new OrdenReparacionCelularNoEncontrada("No se encontraron ordenes de reparaciones");
            }
            var listaOrdenRepaCelDTO = iMapper.Map<IList<DtoOrdenDeReparacionCelular>>(mListaOrdenRepaCel);
            //IList<DtoOrdenDeReparacionCelular> listaOrdenRepaCelDTO = new List<DtoOrdenDeReparacionCelular>();
            //foreach (OrdenDeReparacion item in mListaOrdenRepaCel)
            //{
            //    listaOrdenRepaCelDTO.Add(iMapper.Map<OrdenDeReparacion, DtoOrdenDeReparacionCelular>(item));
            //}
            return listaOrdenRepaCelDTO.ToList();
        }

        public async Task ModificarEstadoOrden(int pId, string pEstado)
        {
            var mOrdenRepaMod = await iUdt.RepositorioOrdenDeReparacion.Obtener(pId);
            if ((mOrdenRepaMod == null)||(mOrdenRepaMod.TipoEquipo.nombre=="Pc") )
            {
                throw new OrdenReparacionCelularNoEncontrada("No se encontro Orden Reparación");
            }
            mOrdenRepaMod.estadoReparacion = pEstado;
            iUdt.RepositorioOrdenDeReparacion.ModificarEntidades(mOrdenRepaMod);
            await iUdt.Guardar();

        }
        //public async Task<int> ObtenerUltimoIdReparacionCel()
        //{
        //    var mListaOrdenRepaCel = await iUdt.RepositorioOrdenDeReparacion.ObtenerUltimoId();
        //    if (mListaOrdenRepaCel == 0)
        //    {
        //        throw new OrdenReparacionCelularNoEncontrada("No se encontraron ordenes de reparaciones");
        //    }
        //    return mListaOrdenRepaCel;
        //}
        public int ObtenerUltimoIdReparacionCel()
        {
            var mListaOrdenRepaCel =  iUdt.RepositorioOrdenDeReparacion.ObtenerUltimoId();
            if (mListaOrdenRepaCel == 0)
            {
                throw new OrdenReparacionCelularNoEncontrada("No se encontraron ordenes de reparaciones");
            }
            return mListaOrdenRepaCel;
        }
        public async Task<ActionResult<IEnumerable<DtoOrdenDeReparacionCelular>>> ObtenerOrdenReparacionCelPage(int pid, int ppage)
        {
            IEnumerable<OrdenDeReparacion> listaOrdenReparacion = await iUdt.RepositorioOrdenDeReparacion.ObtengoListaTodosLosCelulares();
            if (listaOrdenReparacion.Count() == 0)
            {
                throw new OrdenReparacionCelularNoEncontrada("No se encontro listado de orden de reparación");
            }
            var pagePost = Paginacion<OrdenDeReparacion>.CreateAsync(listaOrdenReparacion, pid, ppage);
            var listaOrdenRepaDTO = iMapper.Map<IEnumerable<DtoOrdenDeReparacionCelular>>(pagePost);
            // Response.Headers.Add("X-Pagination",)
            return listaOrdenRepaDTO.ToList();
        }
    }
}
