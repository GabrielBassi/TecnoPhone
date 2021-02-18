using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Modelo
{
    public class Pc
    {
        public int PcId { get; set; }
        public string  diagnostico { get; set; }
        public virtual ModeloPc ModeloPc { get; set; }
    }
}
