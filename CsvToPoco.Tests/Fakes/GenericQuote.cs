using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration.Attributes;
using CsvToPoco.CustomTypeConverters;

namespace CsvToPoco.Tests.Fakes
{
    public partial class GenericQuote
    {
        [Column(TypeName = "Date")]
        [Name("Asof")]
        public DateTime Asof { get; set; }
        [Name("Source")]
        public string Source { get; set; }
        [Name("Contract Code")]
        public string ContractCode { get; set; }
        [Name("Name")]
        public string Name { get; set; }
        [Name("External Id")]
        public string ExternalId { get; set; }
        [Name("Price Type")]
        public string PriceType { get; set; }
        [Name("Price Time")]
        public string PriceTime { get; set; }
        [Name("Instrument")]
        public InstrumentEnum Instrument { get; set; }
        [Name("Value")]
        public double Value { get; set; }

        [Name("Contract Date")]
        [Column(TypeName = "Date")]
        public DateTime? ContractDate { get; set; }
        [Column(TypeName = "Date")]
        [Name("Expiry Date")] 
        public DateTime? ExpiryDate { get; set; }
        [Name("Strike")] 
        public double? Strike { get; set; }
        [Name("Delta")] 
        public double? Delta { get; set; }
        [Name("Implied Vol")] 
        public double? ImpliedVol { get; set; }
        [Name("Open Interest")] 
        public int? OpenInterest { get; set; }
        [Name("Volume")] 
        public int? Volume { get; set; }

    }
}
