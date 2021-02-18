using ApiCelulares.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCelulares.Controllers.DTO;

namespace ApiCelulares.DAL
{
    public class DbCelulares : DbContext
    {
        public DbCelulares()
        {
        }

        public DbCelulares(DbContextOptions<DbCelulares> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Celular> Celulars { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
      //  public DbSet<EstadoDeReparacion> EstadoDeReparacions { get; set; }
        public DbSet<LineaVenta> LineaVentas { get; set; }
        public DbSet<MarcaCelular> MarcaCelulars { get; set; }
        public DbSet<MarcaPc> MarcaPcs { get; set; }
        public DbSet<ModeloCelular> ModeloCelulars { get; set; }
        public DbSet<ModeloPc> ModeloPcs { get; set; }
        public DbSet<OrdenDeReparacion> OrdenDeReparacions { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Pc> Pcs { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedors { get; set; }
        public DbSet<TipoEquipo> TipoEquipos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    
    }
}
