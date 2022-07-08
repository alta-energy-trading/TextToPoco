using System;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration.Attributes;
using TextToPoco;

#nullable disable

namespace CsvToPoco.Tests.Fakes
{
    public class IceCleared
    {
        [Name("TRADE DATE")]
        public DateTime TradeDate { get; set; }
        [Ignore]
        [Column(TypeName = "Date")]
        public DateTime LoadDate { get; set; } = DateTime.Now.Date;
        [Name("HUB")]
        public string Hub { get; set; }
        [Name("PRODUCT")]
        public string Product { get; set; }
        [Name("STRIP")]
        public DateTime? Strip { get; set; }
        [Name("CONTRACT")]
        public string Contract { get; set; }
        [Name("CONTRACT TYPE")]
        public string ContractType { get; set; }
        [Name("SETTLEMENT PRICE")]
        public double SettlementPrice { get; set; }
        [Name("NET CHANGE")]
        public double? NetChange { get; set; }
        [Name("EXPIRATION DATE")]
        public DateTime? ExpirationDate { get; set; }
        [Name("PRODUCT_ID")]
        public string ProductId { get; set; }
    }
}
