using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Excepciones
{
    public class OrdenReparacionPcNoEncontrada : Exception
    {
        public OrdenReparacionPcNoEncontrada(string pCadena) : base(pCadena)
        {

        }
    }
}
