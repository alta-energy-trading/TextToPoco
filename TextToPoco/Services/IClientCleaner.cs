using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TextToPoco
{
    public interface IClientCleaner
    {
        Task<IEnumerable<IClean>> Clean(IDirty dirty);
        List<string> Keys { get; set; }
        Type CleanType { get; set; }
    }
}
