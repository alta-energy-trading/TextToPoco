using System.Collections.Generic;
using System.Threading.Tasks;

namespace TextToPoco
{
    public interface IClientCleaner<TSource, TTarget> 
        where TSource : IDirty
        where TTarget : IClean
    {
        Task<IEnumerable<IClean>> Clean(IDirty dirty);
        List<string> Keys { get; set; }
    }
}
