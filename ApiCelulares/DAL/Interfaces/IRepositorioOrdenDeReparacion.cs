using ApiCelulares.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Interfaces
{
    public interface IRepositorioOrdenDeReparacion : IRepositorioGenerico<OrdenDeReparacion>
    {
         Task<IList<OrdenDeReparacion>> ObtengoListaTodosLasOrdenesCelularPorClienteDni(string pDni);
        bool ConsultarExistenciaCelular(int pId);
        Task<IList<OrdenDeReparacion>> ObtengoListaTodosLosCelulares();
        Task<IList<OrdenDeReparacion>> ObtengoListaTodosLasPC();
        bool ConsultarExistenciaPc(int pId);
        Task<IList<OrdenDeReparacion>> ObtengoListaTodosLasOrdenesPcPorClienteDni(string pDni);
       int ObtenerUltimoId();
    }
}
