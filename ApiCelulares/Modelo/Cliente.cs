using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Modelo
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string dni { get; set; }
        public string direccion { get; set; }
        public virtual IList<OrdenDeReparacion> ListaOrdenDeReparacion { get; set; }
    }
}
