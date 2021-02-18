using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Modelo
{
    public class Celular
    {
        public int CelularId { get; set; }
        public string empresa { get; set; }
        public bool chip { get; set; }
        public bool tarjetaSd { get; set; }
        public bool enciende { get; set; }
        public string diagnostico { get; set; }
        public int pin { get; set; }
        public string patron { get; set; }
        public virtual ModeloCelular ModeloCelular { get; set; }
    }
}
