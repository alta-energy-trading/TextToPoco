using System;
using System.Collections.Generic;

namespace TextToPoco
{
    public interface IObjectifier
    {
        IEnumerable<T> Deserialize<T>(
            TextToPocoArgs args)
             where T : class, new();

        IEnumerable<IEnumerable<T>> BatchDeserialize<T>(
            TextToPocoArgs args)
             where T : class, new();

        List<Exception> Exceptions { get; set; }
    }
}
