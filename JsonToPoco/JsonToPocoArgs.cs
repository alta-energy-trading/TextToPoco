using System;
using System.Collections.Generic;
using System.IO;
using TextToPoco.Core;

namespace JsonToPoco
{
    public class JsonToPocoArgs : ITextToPocoArgs
    {
        public Stream Stream { get; set; }
        public PersistActionEnum PersistAction { get; set; }
        public Type RootType { get; set; }
        public string CollectionName { get; set; }
        public List<string> Keys { get; set; }
        public List<string> PropertiesToInclude { get; set; }
    }
}
