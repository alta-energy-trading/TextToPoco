using System;
using System.Collections.Generic;

namespace CsvToPoco
{
    public interface IImporter
    {
        public List<Exception> Exceptions { get; set; }
        IEnumerable<IEnumerable<T>> Import<T>(IDbContext context, ITextToPocoArgs args, int batchSize, Func<T, T> update = null) where T : class, new();
        IEnumerable<T> Import<T>(IDbContext context, ITextToPocoArgs args, Func<T, T> update = null) where T : class, new();
    }
}
