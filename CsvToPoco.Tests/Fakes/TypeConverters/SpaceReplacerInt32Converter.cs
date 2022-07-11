using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;

namespace CsvToPoco.Tests.Fakes
{
    public class SpaceReplacerInt32Converter : Int32Converter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (String.IsNullOrWhiteSpace(text))
                return null;
            return base.ConvertFromString(text, row, memberMapData);
        }
    }
}
