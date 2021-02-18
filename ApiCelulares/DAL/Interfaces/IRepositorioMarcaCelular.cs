using ApiCelulares.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Interfaces
{
    public interface IRepositorioMarcaCelular : IRepositorioGenerico<MarcaCelular>
    {
        Task<MarcaCelular> ObtenerMarcaCelularPorNombre(string pNombre);
    }
}
