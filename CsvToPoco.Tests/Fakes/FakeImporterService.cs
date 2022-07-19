using System.Collections.Generic;
using System.Linq;
using System;
using TextToPoco;
using CsvToPoco;

namespace CsvToPoco.Tests.Fakes
{
    public class FakeImporterService : IImporter
    {
        public List<Exception> Exceptions { get; set; }

        public FakeImporterService()
        {
            Exceptions = new List<Exception>();
        }

        public IEnumerable<T> Import<T>(IDbContext context, ITextToPocoArgs args) where T : class, new()
        {
            return Enumerable.Range(1, 200000)
                .Select(j => new FakeDirtyObject
                {
                    FakeIntProperty = j,
                    FakeBoolProperty = true
                })
                .Cast<T>();
        }

        public IEnumerable<IEnumerable<T>> Import<T>(IDbContext context, ITextToPocoArgs args, int batchSize) where T : class, new()
        {
            return Enumerable.Range(1, 2)
                .Select(i =>
                    Enumerable.Range(1, batchSize)
                        .Select(j => new FakeDirtyObject
                        {
                            FakeIntProperty = j,
                            FakeBoolProperty = true
                        })
                .Cast<T>());
        }
    }
}
