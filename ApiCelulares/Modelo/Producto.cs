using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Modelo
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string nombre { get; set; }
        public string detalle { get; set; }
        public double precioCompra { get; set; }
        public double precioVenta { get; set; }
        public double stock { get; set; }
        public double stockMinimo { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual Categoria Categoria { get; set; }

        public virtual OrdenDeReparacion OrdenDeReparacion { get; set; }
        public virtual IList<LineaVenta> ListaLineaVenta { get; set; }
    }
}
