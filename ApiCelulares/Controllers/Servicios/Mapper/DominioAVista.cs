
using ApiCelulares.Controllers.DTO;
using ApiCelulares.Modelo;
using AutoMapper;
using ImTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Controllers.Servicios.Mapper
{   
    public class DominioAVista:Profile
    {
        public DominioAVista()
        {
            CreateMap<Cliente, DtoCliente>()
           .ForMember(dto => dto.apellido, map => map.MapFrom(u => u.apellido))
           .ForMember(dto => dto.direccion, map => map.MapFrom(u => u.direccion))
           .ForMember(dto => dto.dni, map => map.MapFrom(u => u.dni))
           .ForMember(dto => dto.email, map => map.MapFrom(u => u.email))
           .ForMember(dto => dto.nombre, map => map.MapFrom(u => u.nombre))
           .ForMember(dto => dto.telefono, map => map.MapFrom(u => u.telefono))
           .ForMember(dto => dto.ClienteId, map => map.MapFrom(u => u.ClienteId));

         CreateMap<OrdenDeReparacion, DtoOrdenDeReparacionCelular>()
        .ForMember(dto => dto.chip, map => map.MapFrom(u => u.TipoEquipo.Celular.chip))
        .ForMember(dto => dto.detalleOrden, map => map.MapFrom(u => u.detalle))
        .ForMember(dto => dto.diagnosticoCelular, map => map.MapFrom(u => u.TipoEquipo.Celular.diagnostico))
        .ForMember(dto => dto.dni, map => map.MapFrom(u => u.Cliente.dni))
        .ForMember(dto => dto.empresa, map => map.MapFrom(u => u.TipoEquipo.Celular.empresa))
        .ForMember(dto => dto.estado, map => map.MapFrom(u => u.estadoReparacion))
        .ForMember(dto => dto.fechaIngreso, map => map.MapFrom(u => u.fechaIngreso))
        .ForMember(dto => dto.fecheEgreso, map => map.MapFrom(u => u.fechaEgreso))
        .ForMember(dto => dto.nombreMarcaCelular, map => map.MapFrom(u => u.TipoEquipo.Celular.ModeloCelular.MarcaCelular.nombre))
        .ForMember(dto => dto.nombreModeloCelular, map => map.MapFrom(u => u.TipoEquipo.Celular.ModeloCelular.nombre))
        .ForMember(dto => dto.patron, map => map.MapFrom(u => u.TipoEquipo.Celular.patron))
        .ForMember(dto => dto.pin, map => map.MapFrom(u => u.TipoEquipo.Celular.pin))
        .ForMember(dto => dto.precio, map => map.MapFrom(u => u.precio))
        .ForMember(dto => dto.tarjetaSD, map => map.MapFrom(u => u.TipoEquipo.Celular.tarjetaSd))
        .ForMember(dto => dto.versionCelular, map => map.MapFrom(u => u.TipoEquipo.Celular.ModeloCelular.version))
         .ForMember(dto => dto.DtoOrdenDeReparacionCelularId, map => map.MapFrom(u => u.OrdenDeReparacionId))
         .ForMember(dto=>dto.detalleReparacion,map=>map.MapFrom(u=>u.detalleReparacion))
         .ForMember(dto => dto.enciende, map => map.MapFrom(u => u.TipoEquipo.Celular.enciende))
         .ForMember(dto => dto.presupuesto, map => map.MapFrom(u => u.presupuesto))
         .ForMember(dto => dto.seña, map => map.MapFrom(u => u.seña))
         .ForMember(dto => dto.proveedor, map => map.MapFrom(u => u.proveedor))
         .ForMember(dto => dto.costoRepuesto, map => map.MapFrom(u => u.costoRepuesto));

           CreateMap<OrdenDeReparacion, DtoOrdenDeReparacionPc>()
            .ForMember(dto => dto.DtoOrdenDeReparacionPcId, map => map.MapFrom(u => u.OrdenDeReparacionId))
            .ForMember(dto => dto.fechaIngreso, map => map.MapFrom(u => u.fechaIngreso))
            .ForMember(dto => dto.fecheEgreso, map => map.MapFrom(u => u.fechaEgreso))
            .ForMember(dto => dto.detalleOrden, map => map.MapFrom(u => u.detalle))
            .ForMember(dto => dto.precio, map => map.MapFrom(u => u.precio))
            .ForMember(dto => dto.diagnosticoPc, map => map.MapFrom(u => u.TipoEquipo.Pc.diagnostico))
            .ForMember(dto => dto.dni, map => map.MapFrom(u => u.Cliente.dni))
            .ForMember(dto => dto.nombreModeloPc, map => map.MapFrom(u => u.TipoEquipo.Pc.ModeloPc.nombre))
            .ForMember(dto => dto.versionPc, map => map.MapFrom(u => u.TipoEquipo.Pc.ModeloPc.version))
            .ForMember(dto => dto.nombreMarcaPc, map => map.MapFrom(u => u.TipoEquipo.Pc.ModeloPc.MarcaPc.nombre))
             .ForMember(dto => dto.estado, map => map.MapFrom(u => u.estadoReparacion))
            .ForMember(dto => dto.detalleReparacion, map => map.MapFrom(u => u.detalleReparacion))
            .ForMember(dto => dto.presupuesto, map => map.MapFrom(u => u.presupuesto))
             .ForMember(dto => dto.seña, map => map.MapFrom(u => u.seña))
             .ForMember(dto => dto.proveedor, map => map.MapFrom(u => u.proveedor))
              .ForMember(dto => dto.costoRepuesto, map => map.MapFrom(u => u.costoRepuesto));

  /*          CreateMap<int,DtoId>()
         .ForMember(dto => dto.DtoIdId, map => map.MapFrom(u => u.))
         .ForMember(dto => dto.direccion, map => map.MapFrom(u => u.direccion))
         .ForMember(dto => dto.dni, map => map.MapFrom(u => u.dni))
         .ForMember(dto => dto.email, map => map.MapFrom(u => u.email))
         .ForMember(dto => dto.nombre, map => map.MapFrom(u => u.nombre))
         .ForMember(dto => dto.telefono, map => map.MapFrom(u => u.telefono))
         .ForMember(dto => dto.ClienteId, map => map.MapFrom(u => u.ClienteId));
  */
        }
      
    }
}
