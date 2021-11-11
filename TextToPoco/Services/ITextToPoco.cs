using System;
using System.Collections.Generic;

namespace TextToPoco
{
    public interface ITextToPoco
    {
        event EventHandler<WarningEventArgs> Warning;
        IEnumerable<T> Run<T>(IDbContext context, IClientImporter importerArg) 
            where T : class, new();
    }
}
