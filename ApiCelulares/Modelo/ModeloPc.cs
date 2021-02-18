using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Modelo
{
    public class ModeloPc
    {
        public int ModeloPcId { get; set; }
        public string nombre { get; set; }
        public string version { get; set; }
        public virtual IList<Pc> ListaPc { get; set; }
        public virtual MarcaPc MarcaPc { get; set; }
    }
}
