using System.Collections.Generic;
using CsvToPoco;

namespace CsvToPoco.Tests.Fakes
{
    public class FakeCleanerService : ICleaner
    {
        IEnumerable<TTarget> ICleaner.Clean<TSource, TTarget>(IDbContext context, IEnumerable<TSource> entities, 
            IClientCleaner cleaner, PersistActionEnum persistAction)
        {
            throw new System.NotImplementedException();
        }
    }
}
