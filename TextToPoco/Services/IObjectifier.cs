using System;
using System.Collections.Generic;

namespace TextToPoco.Core
{
    public interface IObjectifier
    {
        IEnumerable<IEnumerable<T>> Deserialize<T>(ITextToPocoArgs args, int batchSize) where T : class, new();
        IEnumerable<T> Deserialize<T>(ITextToPocoArgs args) where T : class, new();

        List<Exception> Exceptions { get; set; }
    }
}
