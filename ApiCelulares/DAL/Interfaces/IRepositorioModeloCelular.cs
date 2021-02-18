using ApiCelulares.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Interfaces
{
    public interface IRepositorioModeloCelular : IRepositorioGenerico<ModeloCelular>
    {
         Task<ModeloCelular> ObtenerModeloCelularPorNombre(string pNombre);
    }
}
