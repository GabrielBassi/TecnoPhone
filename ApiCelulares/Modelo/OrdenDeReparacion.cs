using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace ApiCelulares.Modelo
{
    public class OrdenDeReparacion
    {
        public int OrdenDeReparacionId { get; set; }
        public DateTime fechaIngreso { get; set; }
        public string fechaEgreso { get; set; }
        public string detalle { get; set; }
        public double precio { get; set; }
        public virtual IList<LineaVenta> ListaLineaVenta { get; set; }
        public virtual IList<Producto> ListaProducto { get; set; }
        public virtual Cliente Cliente { get; set; }
      //  public virtual EstadoDeReparacion EstadoDeReparacion { get; set; }
        public string estadoReparacion { get; set; }
        public string detalleReparacion { get; set; }
        public virtual TipoEquipo TipoEquipo { get; set; }
        public double presupuesto { get; set; }
        public double seña { get; set; }
        public string proveedor { get; set; }
        public double costoRepuesto { get; set; }

    }
    public enum EstadoReparacion
    {

        Reparado,
        EnReparacion,

    }
}
