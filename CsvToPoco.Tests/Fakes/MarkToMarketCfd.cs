using CsvToPoco.CustomTypeConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToPoco.Tests.Fakes
{
    public class MarkToMarketCFD
    {
        [TypeConverter(typeof(StringToIntConverter))]
        public int WeekNumber { get; set; }
        public DateTime Strip { get; set; }
        public DateTime BasisMonth { get; set; }
        public double Value { get; set; }
        public string Curve { get; set; }

        public DateTime Asof { get; set; }
    }
}
