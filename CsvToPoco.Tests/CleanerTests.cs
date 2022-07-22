using CsvToPoco.Tests.Fakes;
using System.Collections.Generic;
using System.Linq;
using CsvToPoco;
using Xunit;

namespace CsvToPoco.Tests
{
    public class CleanerTests
    {
        [Fact]
        public void Can_High_Level_Clean()
        {
            CleanerService cleaner = new CleanerService();
            FakeDbContext context = new FakeDbContext();

            List<FakeDirtyObject> entities = Enumerable.Range(1, 3)
                .Select(i => new FakeDirtyObject
                {
                    FakeIntProperty = i,
                    FakeBoolProperty = true
                })
                .ToList();

            var clientCleaner = new FakeClientCleanerService();

            cleaner.Clean<FakeDirtyObject, FakeCleanObject>(context, entities, clientCleaner, PersistActionEnum.None);
        }

        [Fact]
        public void Can_Clean_With_No_Grouping()
        {
            CleanerService cleaner = new CleanerService();
            FakeDbContext context = new FakeDbContext();

            List<FakeDirtyObject> entities = Enumerable.Range(1, 3)
                .Select(i => new FakeDirtyObject
                {
                    FakeIntProperty = i,
                    FakeBoolProperty = true
                })
                .ToList();

            var clientCleaner = new FakeClientCleanerService();

            clientCleaner.Keys = null;

            cleaner.Clean<FakeDirtyObject, FakeCleanObject>(context, entities, clientCleaner, PersistActionEnum.None);
        }
    }
}
