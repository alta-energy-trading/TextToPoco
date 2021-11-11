using System;
using System.Collections.Generic;

namespace TextToPoco
{
    public interface IImporter
    {
        public List<Exception> Exceptions { get; set; }
        IEnumerable<T> Import<T>(IDbContext context, IClientImporter args) where T : class, new();
    }
}
