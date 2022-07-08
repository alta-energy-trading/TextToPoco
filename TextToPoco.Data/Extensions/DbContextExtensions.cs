using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TextToPoco.Core;

namespace TextToPoco.Data.Extensions
{
    public static class DbContextExtensions
    {
        public static IEnumerable<TEntity> Merge<TEntity>(this IDbContext context, IEnumerable<TEntity> entities, List<string> keys
            , List<string> propertiesToInclude = null)
            where TEntity : class
        {
            var bulkConfig = new BulkConfig
            {
                UpdateByProperties = keys,
                SetOutputIdentity = true,
                PreserveInsertOrder = false,
                PropertiesToIncludeOnCompare = propertiesToInclude
            };

            ((DbContext)context).BulkInsertOrUpdate(entities.ToList(), bulkConfig);

            return entities;
        }

        /// <summary>
        /// Truncates table and adds new entities. Not suitable for batched jobs because each batch would truncate the previous
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="context"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static IEnumerable<TEntity> Replace<TEntity>(this IDbContext context, IEnumerable<TEntity> entities)
            where TEntity : class
        {
            var dbContext = (DbContext)context;

            dbContext.Truncate<TEntity>();
               
            dbContext.BulkInsert(entities.ToList());

            return entities;
        }

        /// <summary>
        /// Simply adds new entities without any key checks
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="context"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static IEnumerable<TEntity> Add<TEntity>(this IDbContext context, IEnumerable<TEntity> entities)
            where TEntity : class
        {
            var dbContext = (DbContext)context;

            dbContext.BulkInsert(entities.ToList());

            return entities;
        }

        /// <summary>
        /// Truncates existing entities without any checks
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="context"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static void Truncate<TEntity>(this IDbContext context)
            where TEntity : class
        {
            var dbContext = (DbContext)context;

            dbContext.Truncate<TEntity>();
        }

        public static IEnumerable<TEntity> EndDate<TEntity>(this IDbContext context, IEnumerable<TEntity> entities, IQueryable<TEntity> affectedEntities, TEntity update)
            where TEntity : class
        {
            var dbContext = (DbContext)context;

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                affectedEntities.BatchUpdate(update);
                dbContext.BulkInsert(entities.ToList());
                transaction.Commit();
            }

            return entities;
        }
    }
}
