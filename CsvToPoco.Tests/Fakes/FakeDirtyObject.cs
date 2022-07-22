

using System;
using System.ComponentModel;

namespace CsvToPoco.Tests.Fakes
{
    public class FakeDirtyObject
    {
        public int FakeIntProperty { get; set; }
        public bool FakeBoolProperty { get; set; }
        [TypeConverter(typeof(ReducePrecisionDateTimeConverter))]
        public DateTime FakeDateTimeProperty { get; set; }
    }
}
