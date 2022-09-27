using System;
using System.Collections.Generic;

namespace CsvToPoco
{
    public interface ITextToPoco
    {
        event EventHandler<WarningEventArgs> Warning;
        IEnumerable<IEnumerable<T>> Run<T>(IDbContext context, ITextToPocoArgs args, int batchSize, Func<T, T> update = null) 
            where T : class, new();

        IEnumerable<T> Run<T>(IDbContext context, ITextToPocoArgs args, Func<T, T> update = null)
            where T : class, new();
    }
}
