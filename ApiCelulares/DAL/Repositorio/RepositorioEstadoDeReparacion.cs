using ApiCelulares.DAL.Interfaces;
using ApiCelulares.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Repositorio
{
    public class RepositorioEstadoDeReparacion : RepositorioGenerico<EstadoDeReparacion, DbCelulares>, IRepositorioEstadoDeReparacion
    {

        public RepositorioEstadoDeReparacion(DbCelulares pContext) : base(pContext)
        {

        }
    }

}