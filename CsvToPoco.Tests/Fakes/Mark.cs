using System;
using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CsvToPoco
{
    public class Mark
    {
        [Index(0)]
        [Format("yyyyMMdd")]
        public DateTime Contract { get; set; }

        [Index(1)]
        public double Quote { get; set; }

        [Index(2)]
        public string Curve { get; set; }

        [Index(3)]
        [Format("yyyyMMdd")]
        public DateTime Asof { get; set; }
    }
}
