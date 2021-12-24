using System;
using System.Collections.Generic;

namespace TextToPoco
{
    public interface IObjectifier
    {
        IEnumerable<IEnumerable<T>> Deserialize<T>(TextToPocoArgs args, int batchSize) where T : class, new();
        IEnumerable<T> Deserialize<T>(TextToPocoArgs args) where T : class, new();

        List<Exception> Exceptions { get; set; }
    }
}
