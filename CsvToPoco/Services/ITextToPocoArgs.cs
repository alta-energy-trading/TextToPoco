using System;
using System.Collections.Generic;
using System.IO;

namespace CsvToPoco
{
    public interface ITextToPocoArgs
    {
        public Stream Stream { get; set; }
        public PersistActionEnum PersistAction { get; set; }
        public List<string> Keys { get; set; }
        public List<string> PropertiesToInclude { get; set; }
    }
}
