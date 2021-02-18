using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Excepciones
{
    public class ClienteExistente : Exception
    {
        public ClienteExistente(string pCadena) : base(pCadena)
        {

        }
    }
}
