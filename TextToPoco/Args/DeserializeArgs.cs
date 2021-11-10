using System.IO;

namespace TextToPoco
{
    public class DeserializeArgs
    {
        public Stream Stream { get; set; }
        public string Delimiter { get; set; }
        public bool HasHeaders { get; set; }
        public ICsvClassMap CsvClassMap { get; set; }
    }
}
