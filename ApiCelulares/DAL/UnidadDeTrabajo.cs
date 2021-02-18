using ApiCelulares.DAL.Interfaces;
using ApiCelulares.DAL.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        private readonly DbCelulares iDbContext;

        public IRepositorioCategoria RepositorioCategoria { get; private set; }
        public IRepositorioCelular RepositorioCelular { get; private set; }
        public IRepositorioCliente RepositorioCliente { get; private set; }
        public IRepositorioEstadoDeReparacion RepositorioEstadoDeReparacion { get; private set; }
        public IRepositorioLineaVenta RepositorioLineaVenta { get; private set; }
        public IRepositorioMarcaCelular RepositorioMarcaCelular { get; private set; }
        public IRepositorioMarcaPc RepositorioMarcaPc { get; private set; }
        public IRepositorioModeloCelular RepositorioModeloCelular { get; private set; }
        public IRepositorioModeloPc RepositorioModeloPc { get; private set; }
        public IRepositorioOrdenDeReparacion RepositorioOrdenDeReparacion { get; private set; }
        public IRepositorioPago RepositorioPago { get; private set; }
        public IRepositorioPc RepositorioPc { get; private set; }
        public IRepositorioProducto RepositorioProducto { get; private set; }
        public IRepositorioProveedor RepositorioProveedor { get; private set; }
        public IRepositorioTipoEquipo RepositorioTipoEquipo { get; private set; }
        public IRepositorioVenta RepositorioVenta { get; private set; }

        public UnidadDeTrabajo(DbCelulares pContext)
        {
            if (pContext == null)
            {
                throw new ArgumentNullException(nameof(pContext));

            }
            iDbContext = pContext;
            RepositorioCategoria = new RepositorioCategoria(iDbContext);
            RepositorioCelular = new RepositorioCelular(iDbContext);
            RepositorioCliente = new RepositorioCliente(iDbContext);
            RepositorioEstadoDeReparacion = new RepositorioEstadoDeReparacion(iDbContext);
            RepositorioLineaVenta = new RepositorioLineaVenta(iDbContext);
            RepositorioMarcaCelular = new RepositorioMarcaCelular(iDbContext);
            RepositorioMarcaPc = new RepositorioMarcaPc(iDbContext);
            RepositorioModeloCelular = new RepositorioModeloCelular(iDbContext);
            RepositorioModeloPc = new RepositorioModeloPc(iDbContext);
            RepositorioOrdenDeReparacion = new RepositorioOrdenDeReparacion(iDbContext);
            RepositorioPago = new RepositorioPago(iDbContext);
            RepositorioPc = new RepositorioPc(iDbContext);
            RepositorioProducto = new RepositorioProducto(iDbContext);
            RepositorioProveedor = new RepositorioProveedor(iDbContext);
            RepositorioTipoEquipo = new RepositorioTipoEquipo(iDbContext);
            RepositorioVenta = new RepositorioVenta(iDbContext);
        }


        /// <summary>
        /// Guarda los cambios la unidad de trabajo 
        /// </summary>
        public async Task Guardar()
        {
            await this.iDbContext.SaveChangesAsync();
        }

    }
}
