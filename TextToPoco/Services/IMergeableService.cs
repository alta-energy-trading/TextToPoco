using System.Collections.Generic;

namespace TextToPoco
{
    public interface IMergeableService
    {
       IEnumerable<TEntity> Merge<TEntity>(
           IDbContext context,
           IEnumerable<TEntity> entities, 
           List<string> keys) where TEntity : class;
    }
}
