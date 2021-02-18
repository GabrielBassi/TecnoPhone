using ApiCelulares.DAL.Interfaces;
using ApiCelulares.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Repositorio
{
    public class RepositorioOrdenDeReparacion : RepositorioGenerico<OrdenDeReparacion, DbCelulares>, IRepositorioOrdenDeReparacion
    {

        public RepositorioOrdenDeReparacion(DbCelulares pContext) : base(pContext)
        {

        }
        public bool ConsultarExistenciaDni(int pid)
        {
            return iDbContext.OrdenDeReparacions.Any(x => x.OrdenDeReparacionId == pid);
        }
        public async Task<IList<OrdenDeReparacion>> ObtengoListaTodosLasOrdenesCelularPorClienteDni(string pDni)
        {
            return await iDbContext.OrdenDeReparacions.Where(x => x.Cliente.dni == pDni && x.TipoEquipo.nombre=="Celular").OrderByDescending(c => c.fechaIngreso).Take(10).ToListAsync();
        }
        public async Task<IList<OrdenDeReparacion>> ObtengoListaTodosLasOrdenesPcPorClienteDni(string pDni)
        {
            return await iDbContext.OrdenDeReparacions.Where(x => x.Cliente.dni == pDni && x.TipoEquipo.nombre == "Pc").OrderByDescending(c=>c.fechaIngreso).Take(10).ToListAsync();
        }
        public bool ConsultarExistenciaCelular(int pId)
        {
            return iDbContext.OrdenDeReparacions.Any(x => x.OrdenDeReparacionId == pId &&x.TipoEquipo.nombre=="Celular");
        }
        public bool ConsultarExistenciaPc(int pId)
        {
            return iDbContext.OrdenDeReparacions.Any(x => x.OrdenDeReparacionId == pId && x.TipoEquipo.nombre == "Pc");
        }
        public async Task<IList<OrdenDeReparacion>> ObtengoListaTodosLosCelulares()
        {
            return await iDbContext.OrdenDeReparacions.Where(x => x.TipoEquipo.nombre=="Celular" && (x.estadoReparacion == "Reparado" || x.estadoReparacion == "A reparar")).ToListAsync();
        }
        public async Task<IList<OrdenDeReparacion>> ObtengoListaTodosLasPC()
        {
            return await iDbContext.OrdenDeReparacions.Where(x => x.TipoEquipo.nombre == "Pc" && (x.estadoReparacion == "Reparado" || x.estadoReparacion== "A reparar")).ToListAsync();
        }
        public  int ObtenerUltimoId()
        {
            var id = iDbContext.OrdenDeReparacions.OrderBy(x => x.OrdenDeReparacionId).Last().OrdenDeReparacionId;

            return  id; 
        }
    }
}
