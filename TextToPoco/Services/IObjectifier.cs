using System;
using System.Collections.Generic;

namespace TextToPoco
{
    public interface IObjectifier
    {
        IEnumerable<T> Deserialize<T>(
            string fullPath, string delimiter = "|")
             where T : class, IDirty, new();

        List<Exception> Exceptions { get; set; }
    }
}
