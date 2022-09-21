using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration.Attributes;

namespace CsvToPoco.Tests.Fakes
{ 
    public class FakeTimeline
    {
        [Key]
        public int Id { get; set; }
        [Name("Month")]
        public int Month { get; set; }
        [Name("Quarter")]
        public int Quarter { get; set; }
        [Name("Year Month")]
        [Column("Year_Month", TypeName = "date")]
        public DateTime YearMonth { get; set; }
        [Name("Year")]
        public int Year { get; set; }
        [Name("Days")]
        public int Days { get; set; }
        [Name("QuarterYear")]
        [StringLength(10)]
        public string QuarterYear { get; set; }
        [Name("MonthSeriesNumber")]
        [StringLength(1)]
        public int MonthSeriesNumber { get; set; }
        [Name("QuarterSeriesNumber")]
        [StringLength(1)]
        public int QuarterSeriesNumber { get; set; }
    }
}
