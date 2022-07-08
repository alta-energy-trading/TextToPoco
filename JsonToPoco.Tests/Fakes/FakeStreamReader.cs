using System.IO;

namespace JsonToPoco.Tests.Fakes
{
    public static class FakeStream
    {
        public static Stream FromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
