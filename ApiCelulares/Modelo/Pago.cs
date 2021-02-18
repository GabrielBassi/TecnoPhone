using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Modelo
{
    public class Pago
    {
        public int PagoId { get; set; }
        public DateTime fechaPago { get; set; }
        public string tipoPago { get; set; }
        public string tipoTarjeta { get; set; }
        public double montoPago { get; set; }
        public virtual Venta Venta { get; set; }

    }
    public enum TipoPago
    {

        TARJETA,

        EFECTIVO,

        FIADO

    }
    public enum TipoTarjeta
    {

        DEBITO,

        CREDITO

    }
}
