using ApiCelulares.DAL.Interfaces;
using ApiCelulares.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Repositorio
{
    public class RepositorioMarcaPc : RepositorioGenerico<MarcaPc, DbCelulares>, IRepositorioMarcaPc
    {

        public RepositorioMarcaPc(DbCelulares pContext) : base(pContext)
        {

        }
    }
}
