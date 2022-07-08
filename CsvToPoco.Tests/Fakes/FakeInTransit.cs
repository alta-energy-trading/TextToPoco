using System;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;
using CsvToPoco.CustomTypeConverters;

namespace CsvToPoco.Tests.Fakes
{
    public class FakeInTransit
    {
        [Key]
        public DateTime Asof { get; set; }
        [TypeConverter(typeof(DecimalToIntConverter))]
        public int OilInTransit { get; set; }
        [StringLength(25)]
        public string UnitOfMeasure { get; set; }
    }
}
