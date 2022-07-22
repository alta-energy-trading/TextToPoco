using CsvToPoco.Tests.Fakes;
using System.Linq;
using CsvToPoco;

using Xunit;

namespace CsvToPoco.Tests
{
    public class ImporterTests
    {
        [Fact]
        public void Can_Import()
        {
            IObjectifier objectifier = new FakeObjectifierService();
            IDbContext dbContext = new FakeDbContext();

            TextImporter importer = new TextImporter(objectifier);

            foreach(var batch in importer.Import<FakeDirtyObject>(dbContext, new CsvToPocoArgs { PersistAction = PersistActionEnum.None }, 2))
            {
                var test = batch.ToList();
            }
        }
    }
}
