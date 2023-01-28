using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Infrastructure.Repository
{
    public interface IRepository<TEntity, T> where TEntity : class
    {
        /// <summary>
        /// Get All entities by the help of where condition we provided.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllEntities(Func<TEntity, bool> where);

        /// <summary>
        /// Create multiple entity or single entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CreateEntity(TEntity model);

        /// <summary>
        /// Update single entity 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> UpdateEntity(TEntity model);

        /// <summary>
        /// Delete single entity It is soft delete hence It will become IsDeleted = true and IsActive= false
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task<bool> DeleteEntity(TEntity items);

        Task<TEntity> GetSingleEntity(Func<TEntity, bool> where);
    }
}
