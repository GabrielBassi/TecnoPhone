using ApiCelulares.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL
{
   public interface IUnidadDeTrabajo
    {
        IRepositorioCategoria RepositorioCategoria { get; }
         IRepositorioCelular RepositorioCelular { get;}
         IRepositorioCliente RepositorioCliente { get;}
         IRepositorioEstadoDeReparacion RepositorioEstadoDeReparacion { get;  }
         IRepositorioLineaVenta RepositorioLineaVenta { get; }
         IRepositorioMarcaCelular RepositorioMarcaCelular { get; }
         IRepositorioMarcaPc RepositorioMarcaPc { get;  }
         IRepositorioModeloCelular RepositorioModeloCelular { get;  }
         IRepositorioModeloPc RepositorioModeloPc { get;}
         IRepositorioOrdenDeReparacion RepositorioOrdenDeReparacion { get; }
         IRepositorioPago RepositorioPago { get; }
         IRepositorioPc RepositorioPc { get;  }
         IRepositorioProducto RepositorioProducto { get; }
         IRepositorioProveedor RepositorioProveedor { get; }
         IRepositorioTipoEquipo RepositorioTipoEquipo { get; }
         IRepositorioVenta RepositorioVenta { get;  }
        Task Guardar();
    }
}
