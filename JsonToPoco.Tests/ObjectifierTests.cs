using JsonToPoco.Tests.Fakes;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace JsonToPoco.Tests
{
    public class ObjectifierTests
    {
        [Fact]
        public void Can_Deserialize()
        {
            var json = "{\"items\":[{\"id\":1,\"name\":\"Henry\"}]}";

            Objectifier objectifier = new Objectifier();
            var args = new JsonToPocoArgs
            {
                RootType = typeof(Root),
                Stream = FakeStream.FromString(json),
                CollectionName = nameof(Root.Items)
            };

            var result = objectifier.Deserialize<Item>(args);

            Assert.Collection(result,
                r => Assert.True(r.Name == "Henry"));
        }
    }
}