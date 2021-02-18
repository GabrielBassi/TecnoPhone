using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Excepciones
{
    public class OrdenReparacionPcExistente : Exception
    {
        public OrdenReparacionPcExistente(string pCadena) : base(pCadena)
        {

        }
    }
}
