using CsvHelper.Configuration.Attributes;
using TextToPoco;

namespace CsvToPoco.Tests.Fakes
{
    public class FakeDirtyObject
    {
        [Name("FakeIntProperty")]
        public int FakeIntProperty { get; set; }
        [Name("FakeBoolProperty")]
        public bool FakeBoolProperty { get; set; }
        [TypeConverter(typeof(FakeDoubleConverter))]
        //[Name("FakeDecimalProperty")]
        [Ignore]
        public decimal FakeDecimalProperty { get; set; }
        //[Name("FakeStringProperty")]
        [Ignore]
        public string FakeStringProperty { get; set; }
    }
}
