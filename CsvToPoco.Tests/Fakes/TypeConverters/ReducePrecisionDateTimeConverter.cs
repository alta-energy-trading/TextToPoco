using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Linq;

namespace CsvToPoco.Tests.Fakes
{
    public class ReducePrecisionDateTimeConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (String.IsNullOrWhiteSpace(text))
                return null;
            else
            {
                var parts = text.Trim().Split(".");
                var timeInSeconds = parts[0];
                var millis = parts[1];
                var lessPreciseTime = String.Join(".", timeInSeconds, millis.Substring(0, 3));
                return DateTime.Parse(lessPreciseTime);
            }
        }
    }
}
