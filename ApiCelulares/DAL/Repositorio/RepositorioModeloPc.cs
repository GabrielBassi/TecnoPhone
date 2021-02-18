using ApiCelulares.DAL.Interfaces;
using ApiCelulares.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Repositorio
{
    public class RepositorioModeloPc : RepositorioGenerico<ModeloPc, DbCelulares>, IRepositorioModeloPc
    {

        public RepositorioModeloPc(DbCelulares pContext) : base(pContext)
        {

        }
    }
}
