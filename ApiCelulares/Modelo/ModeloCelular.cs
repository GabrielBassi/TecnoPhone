using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Modelo
{
    public class ModeloCelular
    {
        public int ModeloCelularId { get; set; }
        public string nombre { get; set; }
        public string version { get; set; }
        public virtual IList<Celular> ListaCelular { get; set; }
        public virtual MarcaCelular MarcaCelular { get; set; }
    }
}
