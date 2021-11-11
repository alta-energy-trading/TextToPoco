using System.Collections.Generic;
using System.IO;

namespace TextToPoco
{
    public class TextToPocoArgs
    {
        public Stream Stream { get; set; }
        public string Delimiter { get; set; }
        public bool HasHeaders { get; set; }
        public bool Persist { get; set; }
        public List<string> Keys { get; set; }
    }
}
