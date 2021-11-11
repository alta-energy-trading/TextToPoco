using System.Collections.Generic;

namespace TextToPoco.Tests.Fakes
{
    public class FakeMergeService : IMergeableService
    {
        public IEnumerable<TEntity> Merge<TEntity>(IDbContext context, IEnumerable<TEntity> entities, List<string> keys) where TEntity : class
        {
            return entities;
        }
    }
}
