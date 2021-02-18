using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Excepciones
{
    public class OrdenReparacionCelularNoEncontrada : Exception
    {
        public OrdenReparacionCelularNoEncontrada(string pCadena) : base(pCadena)
        {

        }
    }
}
