using ApiCelulares.DAL.Interfaces;
using ApiCelulares.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Repositorio
{
    public class RepositorioProveedor : RepositorioGenerico<Proveedor, DbCelulares>, IRepositorioProveedor
    {

        public RepositorioProveedor(DbCelulares pContext) : base(pContext)
        {

        }
    }
}
