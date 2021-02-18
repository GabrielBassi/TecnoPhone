using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Modelo
{
    public class LineaVenta
    {
        public int LineaVentaId { get; set; }
        public double cantidad { get; set; }
        public double descuento { get; set; }
        public virtual Venta Venta { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual OrdenDeReparacion OrdenDeReparacion {get;set;}
    }
}
