using ApiCelulares.DAL.Interfaces;
using ApiCelulares.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Repositorio
{
    public class RepositorioPago : RepositorioGenerico<Pago, DbCelulares>, IRepositorioPago
    {

        public RepositorioPago(DbCelulares pContext) : base(pContext)
        {

        }
    }
}
