using System.Collections.Generic;
using System.Threading.Tasks;

namespace TextToPoco
{
    public interface IClientCleaner
    {
        Task<IEnumerable<TTarget>> Clean<TSource, TTarget>(TSource dirty);
        List<string> Keys { get; set; }
    }
}
