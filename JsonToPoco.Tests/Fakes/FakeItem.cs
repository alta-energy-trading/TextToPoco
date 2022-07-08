using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JsonToPoco.Tests.Fakes
{
    public class Item
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("items")]
        public IEnumerable<Item> Items { get; set; }
    }
}
