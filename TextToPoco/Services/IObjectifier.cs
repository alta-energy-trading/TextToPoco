using System;
using System.Collections.Generic;

namespace TextToPoco
{
    public interface IObjectifier
    {
        IEnumerable<T> Deserialize<T>(
            DeserializeArgs args)
             where T : class, IDirty, new();

        List<Exception> Exceptions { get; set; }
    }
}
