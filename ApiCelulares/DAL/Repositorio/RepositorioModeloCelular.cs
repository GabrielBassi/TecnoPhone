using ApiCelulares.DAL.Interfaces;
using ApiCelulares.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Repositorio
{
    public class RepositorioModeloCelular : RepositorioGenerico<ModeloCelular, DbCelulares>, IRepositorioModeloCelular
    {

        public RepositorioModeloCelular(DbCelulares pContext) : base(pContext)
        {

        }
        public async Task<ModeloCelular> ObtenerModeloCelularPorNombre(string pNombre)
        {
            return await iDbContext.ModeloCelulars.Where(x => x.nombre == pNombre).FirstOrDefaultAsync();
        }
    }
}
