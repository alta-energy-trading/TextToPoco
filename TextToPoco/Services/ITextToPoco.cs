using System;
using System.Collections.Generic;

namespace TextToPoco.Core
{
    public interface ITextToPoco
    {
        event EventHandler<WarningEventArgs> Warning;
        IEnumerable<IEnumerable<T>> Run<T>(IDbContext context, ITextToPocoArgs args, int batchSize) 
            where T : class, new();

        IEnumerable<T> Run<T>(IDbContext context, ITextToPocoArgs args)
            where T : class, new();
    }
}
