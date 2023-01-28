using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopBridge.Core.Entities.Common;
using ShopBridge.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Infrastructure.Implementation
{
    public class Implementation<TEntity, T> : IRepository<TEntity, T> where TEntity : class
    {
        private readonly ShopBridgeContext context;
        private readonly DbSet<TEntity> TEntities;

        public Implementation(IConfiguration configuration)
        {
            context = new ShopBridgeContext(configuration);
            TEntities = context.Set<TEntity>();
        }

        public async Task<bool> CreateEntity(TEntity model)
        {
            try
            {
                await TEntities.AddAsync(model);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> DeleteEntity(TEntity items)
        {
            try
            {
                context.Update(items);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllEntities(Func<TEntity, bool> where)
        {
            try
            {
                IQueryable<TEntity> dbQuery = context.Set<TEntity>();
                var tList = dbQuery.AsNoTracking().Where(where).ToList<TEntity>();
                return await Task.Run(() => tList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<TEntity> GetSingleEntity(Func<TEntity, bool> where)
        {
            try
            {
                IQueryable<TEntity> dbQuery = context.Set<TEntity>();
                var tModel = dbQuery.FirstOrDefault(where);
                return await Task.Run(() => tModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> UpdateEntity(TEntity model)
        {
            try
            {
                context.Update(model);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
