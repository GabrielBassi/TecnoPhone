using ApiCelulares.DAL.Interfaces;
using ApiCelulares.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Repositorio
{
    public class RepositorioLineaVenta : RepositorioGenerico<LineaVenta, DbCelulares>, IRepositorioLineaVenta
    {

        public RepositorioLineaVenta(DbCelulares pContext) : base(pContext)
        {

        }
    }
}
