using System;
using System.Collections.Generic;
using System.IO;

namespace TextToPoco
{
    public class TextToPocoArgs
    {
        public Stream Stream { get; set; }
        public string Delimiter { get; set; }
        public string Qualifier { get; set; }
        public bool HasHeaders { get; set; }
        public PersistActionEnum PersistAction { get; set; }
        public List<string> Keys { get; set; }
    }
}
