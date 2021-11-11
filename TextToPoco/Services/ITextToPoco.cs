using System;
using System.Collections.Generic;

namespace TextToPoco
{
    public interface ITextToPoco
    {
        event EventHandler<WarningEventArgs> Warning;
        void Run<T>(IDbContext context, IClientImporter importerArg) 
            where T : class, new();
        void Run<T>(IDbContext context, IClientImporter importerArg, IEnumerable<IClientCleaner> cleaners) 
            where T : class, new();
    }
}
