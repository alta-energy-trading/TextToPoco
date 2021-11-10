using System.Collections.Generic;
using System.Threading.Tasks;

namespace TextToPoco
{
    public interface IClientCleaner<TSource, TTarget> 
        where TSource : IDirty
        where TTarget : IClean
    {
        Task<IEnumerable<TTarget>> Clean(TSource dirty);
        List<string> Keys { get; set; }
    }
}
