using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CsvToPoco.Tests.Fakes
{
    public class FakeDoubleConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (text == "UNCH")
                return (decimal)0;
            else
                return base.ConvertFromString(text, row, memberMapData);
        }
    }
}
