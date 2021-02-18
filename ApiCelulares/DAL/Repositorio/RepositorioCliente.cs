using ApiCelulares.DAL.Interfaces;
using ApiCelulares.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Repositorio
{
    public class RepositorioCliente : RepositorioGenerico<Cliente, DbCelulares>, IRepositorioCliente
    {

        public RepositorioCliente(DbCelulares pContext) : base(pContext)
        {

        }
        public async Task<Cliente> ObtenerClientePorDni(string dni)
        {
            return await iDbContext.Clientes.Where(x => x.dni == dni).FirstOrDefaultAsync();
        }
        public bool ConsultarExistencia(string pDni)
        {
            return iDbContext.Clientes.Any(x => x.dni == pDni);
        }
        public async Task<Cliente> ObtengoClienteDtoPorDni(string pDni)
        {
            return await iDbContext.Clientes.Where(x => x.dni == pDni).FirstOrDefaultAsync();
        }

        public bool ConsultarExistenciaCliente(string pDni)
        {
            return iDbContext.Clientes.Any(x => x.dni == pDni);
        }
    }
}
