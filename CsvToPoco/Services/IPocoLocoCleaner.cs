using System.Collections.Generic;

namespace CsvToPoco
{
    public interface IPocoLocoCleaner
    {
        IEnumerable<TTarget> Clean<TSource, TTarget>(IDbContext context, IEnumerable<TSource> entities, IClientCleaner clientCleaner, PersistActionEnum persistAction = PersistActionEnum.Merge)
            where TSource : class
            where TTarget : class;
    }
}
