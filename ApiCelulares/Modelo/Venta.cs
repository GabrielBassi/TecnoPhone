using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Modelo
{
    public class Venta
    {
        public int VentaId { get; set; }
        public DateTime fechaVenta { get; set; }
        public double monto { get; set; }
        public bool pagado { get; set; }
        public virtual IList<Pago> ListaPagos { get; set; }
        public virtual IList<LineaVenta> ListaLineaVentas { get; set; }

    }
}
