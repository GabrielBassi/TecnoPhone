using ApiCelulares.DAL.Interfaces;
using ApiCelulares.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Repositorio
{
    public class RepositorioMarcaCelular : RepositorioGenerico<MarcaCelular, DbCelulares>, IRepositorioMarcaCelular
    {

        public RepositorioMarcaCelular(DbCelulares pContext) : base(pContext)
        {

        }
        public async Task<MarcaCelular> ObtenerMarcaCelularPorNombre(string pNombre)
        {
            return await iDbContext.MarcaCelulars.Where(x => x.nombre == pNombre).FirstOrDefaultAsync();
        }
    }
}
