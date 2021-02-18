using ApiCelulares.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Interfaces
{
    public interface IRepositorioCliente : IRepositorioGenerico<Cliente>
    {
        Task<Cliente> ObtenerClientePorDni(string dni);
        bool ConsultarExistencia(string pDni);

        Task<Cliente> ObtengoClienteDtoPorDni(string pDni);
        bool ConsultarExistenciaCliente(string pDni);
    }
}
