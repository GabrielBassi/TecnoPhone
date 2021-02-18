using ApiCelulares.Controllers.DTO;
using ApiCelulares.DAL;
using ApiCelulares.Modelo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCelulares.Excepciones;
using AutoMapper;

namespace ApiCelulares.Controllers.Servicios.LogicaDelNegocio
{
    public class LogicaCliente
    {
        private readonly IUnidadDeTrabajo iUdt;
        private readonly IMapper iMapper;
        public LogicaCliente(IUnidadDeTrabajo pUdt, IMapper pMapper)
        {
            iUdt = pUdt;
            iMapper = pMapper;
        }

        public async Task<ActionResult<IEnumerable<DtoCliente>>> ObtenerClientesDTO()
        {
            IEnumerable<Cliente> listaClientes = await iUdt.RepositorioCliente.ObtenerTodos();
            if (listaClientes.Count() == 0)
            {
                throw new ClienteNoEncontrado("No se encontro el listado de clientes");
            }
            var listaClientesDTO = iMapper.Map<IList<DtoCliente>>(listaClientes);
            //IList<DtoCliente> listaClientesDTO = new List<DtoCliente>();
            //foreach (Cliente item in listaClientes)
            //{
            //    listaClientesDTO.Add(iMapper.Map<Cliente, DtoCliente>(item));
            //}
            return listaClientesDTO.ToList();
        }

        public async Task<ActionResult<DtoCliente>> ObtenerClienteDtoPorDni(string pDni)
        {
            var mCliente = await iUdt.RepositorioCliente.ObtengoClienteDtoPorDni(pDni);
            if (mCliente == null)
            {
                throw new ClienteNoEncontrado("No se encontro el cliente");
            }
            DtoCliente mClienteDniDto = iMapper.Map<Cliente, DtoCliente>(mCliente);
            return mClienteDniDto;
        }

        public async Task AgregarCliente (DtoCliente pClienteDto)
        {
            bool existencia = iUdt.RepositorioCliente.ConsultarExistenciaCliente(pClienteDto.dni);
            if (existencia == true)
            {
                throw new ClienteExistente("Ya existe el cliente ingresado");
            }
            Cliente iCliente = new Cliente
            {
                nombre = pClienteDto.nombre,
                apellido = pClienteDto.apellido,
                telefono = pClienteDto.telefono,
                email = pClienteDto.email,
                dni = pClienteDto.dni,
                direccion = pClienteDto.direccion,
            };
            await iUdt.RepositorioCliente.Agregar(iCliente);
            await iUdt.Guardar();
        }

        public async Task ModificarCliente(DtoCliente pClienteDto)
        {
            bool existenciaCliente = iUdt.RepositorioCliente.ConsultarExistenciaCliente(pClienteDto.dni);
            if (existenciaCliente == false)
            {
                throw new ClienteNoEncontrado("No se encontro el cliente");
            }
            var mCliente = await iUdt.RepositorioCliente.ObtengoClienteDtoPorDni(pClienteDto.dni);
            mCliente.nombre = pClienteDto.nombre;
            mCliente.apellido = pClienteDto.apellido;
            mCliente.telefono = pClienteDto.telefono;
            mCliente.email = pClienteDto.email;
            mCliente.dni = pClienteDto.dni;
            mCliente.direccion = pClienteDto.direccion;
            iUdt.RepositorioCliente.ModificarEntidades(mCliente);
            await iUdt.Guardar();
        }

        public async Task EliminarClienteDTO (string pDni)
        {
            var mClienteEliminar = await iUdt.RepositorioCliente.ObtengoClienteDtoPorDni(pDni); // revisar esto!
            if (mClienteEliminar == null)
            {
                throw new ClienteNoEncontrado("No se encontro el cliente");
            }
            iUdt.RepositorioCliente.Eliminar(mClienteEliminar);
            await iUdt.Guardar();
        }
    }
}
