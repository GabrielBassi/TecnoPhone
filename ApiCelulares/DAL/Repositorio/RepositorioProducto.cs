using ApiCelulares.DAL.Interfaces;
using ApiCelulares.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Repositorio
{
    public class RepositorioProducto : RepositorioGenerico<Producto, DbCelulares>, IRepositorioProducto
    {

        public RepositorioProducto(DbCelulares pContext) : base(pContext)
        {

        }
    }
}