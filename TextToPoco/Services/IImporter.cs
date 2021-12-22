using System;
using System.Collections.Generic;

namespace TextToPoco
{
    public interface IImporter
    {
        public List<Exception> Exceptions { get; set; }
        IEnumerable<T> Import<T>(IDbContext context, TextToPocoArgs args) where T : class, new();
        IEnumerable<IEnumerable<T>> BatchImport<T>(IDbContext context, TextToPocoArgs args) where T : class, new();
    }
}
