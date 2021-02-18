using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Excepciones
{
    public class OrdenReparacionCelularExistente : Exception
    {
        public OrdenReparacionCelularExistente(string pCadena) : base(pCadena)
        {

        }
    }
}
