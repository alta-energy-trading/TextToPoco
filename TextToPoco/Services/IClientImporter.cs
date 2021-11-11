using System.Collections.Generic;

namespace TextToPoco
{
    public interface IClientImporter
    {
        public bool Persist { get; set; }
        public DeserializeArgs DeserializeArgs { get; set; }
        public List<string> Keys { get; set; }
        
    }
}
