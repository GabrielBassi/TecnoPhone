using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Modelo
{
    public class MarcaPc
    {
        public int MarcaPcId { get; set; }
        public string nombre { get; set; }
       
        public virtual IList<ModeloPc> ListaModeloPc { get; set; }
    }
}
