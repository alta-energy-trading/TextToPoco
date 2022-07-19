using System.Collections.Generic;

namespace CsvToPoco
{
    public interface ICleaner
    {
        IEnumerable<TTarget> Clean<TSource, TTarget>(IDbContext context, IEnumerable<TSource> entities, 
            IClientCleaner cleaner, PersistActionEnum persistAction = PersistActionEnum.Merge) 
            where TSource : class
            where TTarget : class;
    }
}
