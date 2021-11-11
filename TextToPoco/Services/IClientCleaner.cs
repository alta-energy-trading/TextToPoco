using System.Collections.Generic;
using System.Threading.Tasks;

namespace TextToPoco
{
    public interface IClientCleaner<IDirty, IClean> 
    {
        Task<IEnumerable<IClean>> Clean(IDirty dirty);
        List<string> Keys { get; set; }
    }
}
