using CsvToPoco.Tests.Fakes;
using System.Collections.Generic;
using System.Linq;
using CsvToPoco;
using Xunit;

namespace CsvToPoco.Tests
{
    public class PocoLocoCleanerTests
    {
        [Fact]
        public void Can_Poco_Loco_Clean()
        {
            Cleaner cleaner = new Cleaner(new CleanerService());
            FakeDbContext context = new FakeDbContext();

            List<FakeDirtyObject> entities = Enumerable.Range(1, 3)
                .Select(i => new FakeDirtyObject
                {
                    FakeIntProperty = i,
                    FakeBoolProperty = true
                })
                .ToList();

            var clientCleaner = new FakeClientCleanerService();

            cleaner.Clean<FakeDirtyObject, FakeCleanObject>(context, entities, clientCleaner, PersistActionEnum.None );
        }
    }
}
