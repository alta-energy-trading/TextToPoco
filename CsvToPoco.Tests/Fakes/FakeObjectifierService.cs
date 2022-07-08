using System;
using System.Collections.Generic;
using System.Linq;
using TextToPoco.Core;

namespace CsvToPoco.Tests.Fakes
{
    public class FakeObjectifierService : IObjectifier
    {
        public FakeObjectifierService()
        {
            Exceptions = new List<Exception>();
        }

        public List<Exception> Exceptions { get; set; }

        public IEnumerable<IEnumerable<T>> Deserialize<T>(ITextToPocoArgs args, int batchSize) where T : class, new()
        {
            return Enumerable.Range(1, 2)
                .Select(i => Enumerable.Range(1, batchSize)
                    .Select(j => new FakeDirtyObject
                    {
                        FakeIntProperty = j,
                        FakeBoolProperty = true
                    })
                .Cast<T>());
        }

        public IEnumerable<T> Deserialize<T>(ITextToPocoArgs args) where T : class, new()
        {
            return Enumerable.Range(1, 200000)
                .Select(j => new FakeDirtyObject
                {
                    FakeIntProperty = j,
                    FakeBoolProperty = true
                })
                .Cast<T>();
        }
    }
}
