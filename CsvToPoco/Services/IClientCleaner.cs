using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsvToPoco
{
    public interface IClientCleaner
    {
        Task<IEnumerable<TTarget>> Clean<TSource, TTarget>(TSource dirty) where TTarget : class;
        List<string> Keys { get; set; }
        List<string> PropertiesToInclude { get; set; }
    }
}
