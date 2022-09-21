using CsvHelper.Configuration.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsvToPoco.Tests.Fakes
{
    public class FakeEexOption
    {
        [Column(TypeName = "Date")]
        [Ignore]
        public DateTime QuoteDate { get; set; }
        [CsvHelper.Configuration.Attributes.Index(0)] // Have to use Index because file is in weird format
        public string RowType { get; set; }
        [CsvHelper.Configuration.Attributes.Index(1)] // Have to use Index because file is in weird format
        public string Product { get; set; }
        [CsvHelper.Configuration.Attributes.Index(2)]
        public string LongName { get; set; }
        [CsvHelper.Configuration.Attributes.Index(3)]
        public string Underlying { get; set; }
        [CsvHelper.Configuration.Attributes.Index(4)]
        public string Maturity { get; set; }
        [Column(TypeName = "Date")]
        [CsvHelper.Configuration.Attributes.Index(5)]
        public DateTime DeliveryStart { get; set; }
        [Column(TypeName = "Date")]
        [CsvHelper.Configuration.Attributes.Index(6)]
        public DateTime DeliveryEnd { get; set; }
        [CsvHelper.Configuration.Attributes.Index(7)]
        public string Type { get; set; }
        [CsvHelper.Configuration.Attributes.Index(8)]
        public double Strike { get; set; }
        [CsvHelper.Configuration.Attributes.Index(9)]
        public double? OpenPrice { get; set; }
        [CsvHelper.Configuration.Attributes.Index(10)]
        public DateTime? TimestampOpenPrice { get; set; }
        [CsvHelper.Configuration.Attributes.Index(11)]
        public double? HighPrice { get; set; }
        [CsvHelper.Configuration.Attributes.Index(12)]
        public DateTime? TimestampHighPrice { get; set; }
        [CsvHelper.Configuration.Attributes.Index(13)]
        public double? LowPrice { get; set; }
        [CsvHelper.Configuration.Attributes.Index(14)]
        public DateTime? TimestampLowPrice { get; set; }
        [CsvHelper.Configuration.Attributes.Index(15)]
        public double? LastPrice { get; set; }
        [CsvHelper.Configuration.Attributes.Index(16)]
        public DateTime? TimestampLastPrice { get; set; }
        [CsvHelper.Configuration.Attributes.Index(17)]
        public double? SettlementPrice { get; set; }
        [CsvHelper.Configuration.Attributes.Index(18)]
        public string UnitofPrices { get; set; }
        [CsvHelper.Configuration.Attributes.Index(19)]
        public int? LotSize { get; set; }
        [CsvHelper.Configuration.Attributes.Index(20)]
        public int? TradedLots { get; set; }
        [CsvHelper.Configuration.Attributes.Index(21)]
        public int? NumberofTrades { get; set; }
        [CsvHelper.Configuration.Attributes.Index(22)]
        public int? TradedVolume { get; set; }
        [CsvHelper.Configuration.Attributes.Index(23)]
        public int? OpenInterestLots { get; set; }
        [CsvHelper.Configuration.Attributes.Index(24)]
        public int? OpenInterestVolume { get; set; }
        [CsvHelper.Configuration.Attributes.Index(25)]
        public string UnitofVolumes { get; set; }
    }
}
