using CsvHelper.Configuration;
using System.Collections.Generic;
using System.IO;

namespace CsvToPoco
{
    public interface IFileImporterService
    {
        public IEnumerable<T> Import<T>(Stream stream, ClassMap classMap) where T : class, new();
    }
}
