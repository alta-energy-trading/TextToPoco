using System;
using System.Collections.Generic;

namespace TextToPoco
{
    public interface ITextToPoco
    {
        event EventHandler<WarningEventArgs> Warning;
        IEnumerable<T> Run<T>(IDbContext context, TextToPocoArgs args) 
            where T : class, new();
    }
}
