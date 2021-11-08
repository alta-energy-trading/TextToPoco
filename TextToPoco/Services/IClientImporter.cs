using System.Collections.Generic;

namespace TextToPoco
{
    public interface IClientImporter
    {
        public bool Persist { get; set; }
        public string Delimiter { get; set; }
        public string FullPath { get; set; }
        public List<string> Keys { get; set; }

        public List<IClientCleaner> Cleaners { get; set; }
    }
}
