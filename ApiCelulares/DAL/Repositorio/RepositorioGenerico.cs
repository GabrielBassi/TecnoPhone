using ApiCelulares.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Repositorio
{
    /// <summary>
    /// Implementacion  del Repositorio generico
    /// </summary>
    /// <typeparam name="TEntity"> Dominio de la cual se realizará el Repositorio</typeparam>
    /// <typeparam name="TDbContext"> Acceso a Base de Datos</typeparam>
    public abstract class RepositorioGenerico<TEntity, TDbContext> : IRepositorioGenerico<TEntity>
       where TEntity : class
       where TDbContext : DbContext
    {
        protected readonly TDbContext iDbContext;
        public RepositorioGenerico(TDbContext pContext)
        {
            if (pContext == null)
            {
                throw new ArgumentNullException(nameof(pContext));
            }
            this.iDbContext = pContext;
        }

        public async Task Agregar(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            await this.iDbContext.Set<TEntity>().AddAsync(pEntity);
        }
        public void Eliminar(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            this.iDbContext.Set<TEntity>().Remove(pEntity);

        }

        public async Task<TEntity> Obtener(int pId)
        {
            return await this.iDbContext.Set<TEntity>().FindAsync(pId);
        }

        public async Task<IEnumerable<TEntity>> ObtenerTodos()
        {
            return await this.iDbContext.Set<TEntity>().ToListAsync();
        }
        public void ModificarEntidades(TEntity pEntity)
        {
            this.iDbContext.Entry(pEntity).State = EntityState.Modified;
        }

    }
}
