using CsvToPoco.Tests.Fakes;
using System.Collections.Generic;
using System.Linq;
using TextToPoco.Core;
using TextToPoco.Services;
using Xunit;

namespace CsvToPoco.Tests
{
    public class CsvToPocoTests
    {
        [Fact]
        public void Can_Convert_Csv_To_Poco()
        {
            FakeImporterService importer = new FakeImporterService();
            FakeDbContext dbContext = new FakeDbContext();

            List<FakeDirtyObject> entities = Enumerable.Range(1, 3)
                .Select(i => new FakeDirtyObject
                {
                    FakeIntProperty = i,
                    FakeBoolProperty = true
                })
                .ToList();

            var sut = new Importer(importer);
            sut.Run<FakeDirtyObject>(dbContext, new CsvToPocoArgs());
        }
    }
}
