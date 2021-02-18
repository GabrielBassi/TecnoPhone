using ApiCelulares.DAL.Interfaces;
using ApiCelulares.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Repositorio
{
    public class RepositorioCelular : RepositorioGenerico<Celular, DbCelulares>, IRepositorioCelular
    {

        public RepositorioCelular(DbCelulares pContext) : base(pContext)
        {

        }
    }
}
