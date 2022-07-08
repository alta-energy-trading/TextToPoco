using System.Collections.Generic;
using TextToPoco.Core;

namespace PocoLoco
{
    public interface IPocoLocoCleaner
    {
        IEnumerable<TTarget> Clean<TSource, TTarget>(IDbContext context, IEnumerable<TSource> entities, IClientCleaner clientCleaner, PersistActionEnum persistAction = PersistActionEnum.Merge)
            where TSource : class
            where TTarget : class;
    }
}
