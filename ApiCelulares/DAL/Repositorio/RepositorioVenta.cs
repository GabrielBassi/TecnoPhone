using ApiCelulares.DAL.Interfaces;
using ApiCelulares.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Repositorio
{
    public class RepositorioVenta : RepositorioGenerico<Venta, DbCelulares>, IRepositorioVenta
    {

        public RepositorioVenta(DbCelulares pContext) : base(pContext)
        {

        }
    }
}
