using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Modelo
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string nombreCategoria { get; set; }
        public virtual IList<Producto> ListaProducto { get; set; }
    }
}
