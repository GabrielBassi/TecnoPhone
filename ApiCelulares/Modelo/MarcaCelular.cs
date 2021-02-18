using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Modelo
{
    public class MarcaCelular
    {
        public int MarcaCelularId { get; set; }
        public string nombre { get; set; }
      
        public virtual IList<ModeloCelular>Listamodelocelular { get; set; }
    }
}
