using CsvHelper.Configuration;
using System.Collections.Generic;
using System.IO;

namespace CsvToPoco
{
    public class CsvToPocoArgs : ITextToPocoArgs
    {
        public string Delimiter { get; set; }
        public string Qualifier { get; set; }
        public bool HasHeaders { get; set; }
        public ClassMap ClassMap { get; set; }
        public Stream Stream { get; set; }
        public PersistActionEnum PersistAction { get; set; }
        public List<string> Keys { get; set; }
        public List<string> PropertiesToInclude { get; set; }
        public List<string> AcceptedDateFormats { get; set; }
        public List<string> SkipRowsBeginningWith { get; set; }
    }
}
