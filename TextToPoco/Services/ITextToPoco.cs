using System;
using System.Collections.Generic;

namespace TextToPoco
{
    public interface ITextToPoco
    {
        event EventHandler<WarningEventArgs> Warning;
        void Run<T>(IDbContext context, IClientImporter importerArg) 
            where T : class, IDirty, new();
        void Run<T>(IDbContext context, IClientImporter importerArg, IEnumerable<IClientCleaner<IDirty, IClean>> cleaners) 
            where T : class, IDirty, new();
    }
}
