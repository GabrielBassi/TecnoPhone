using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Excepciones
{
    public class ClienteNoEncontrado : Exception
    {
        public ClienteNoEncontrado(string pCadena) : base(pCadena)
        {

        }
    }
}
