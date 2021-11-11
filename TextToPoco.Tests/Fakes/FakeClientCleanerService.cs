using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TextToPoco;

namespace TextToPoco.Tests.Fakes
{
    public class FakeClientCleanerService : IClientCleaner<FakeDirtyObject, FakeCleanObject>
    {
        public List<string> Keys { get; set; }
        public Type CleanType { get; set; }

        public FakeClientCleanerService()
        {
            Keys = new List<string>
            {
                nameof(FakeCleanObject.FakeIntProperty)
            };
            CleanType = typeof(FakeCleanObject);
        }

        public Task<IEnumerable<FakeCleanObject>> Clean(FakeDirtyObject dirty)
        {
            var result = new List<FakeCleanObject> { new FakeCleanObject() };
            return Task.FromResult((IEnumerable<FakeCleanObject>)result);
        }
    }
}
