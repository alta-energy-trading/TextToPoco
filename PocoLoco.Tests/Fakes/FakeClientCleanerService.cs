using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocoLoco.Tests.Fakes
{
    public class FakeClientCleanerService : IClientCleaner
    {
        public List<string> Keys { get; set; }
        public List<string> PropertiesToInclude { get; set; }

        public FakeClientCleanerService()
        {
            Keys = new List<string>
            {
                nameof(FakeCleanObject.FakeIntProperty)
            };
        }

        public Task<IEnumerable<TTarget>> Clean<TSource, TTarget>(TSource dirty) where TTarget : class
        {
            var result = new List<FakeCleanObject> { new FakeCleanObject() };
            return Task.FromResult((IEnumerable<TTarget>)result);
        }
    }
}
