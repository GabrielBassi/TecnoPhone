using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Interfaces
{
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        Task Agregar(TEntity pEntity);
        void Eliminar(TEntity pEntity);
        Task<IEnumerable<TEntity>> ObtenerTodos();
        Task<TEntity> Obtener(int pId);
        void ModificarEntidades(TEntity pEntity);
    }
}
