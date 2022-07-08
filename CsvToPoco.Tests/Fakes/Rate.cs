using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToPoco.Tests.Fakes
{
    [Table("Rate", Schema = "ECB")]
    public class Rate
    {
        [Ignore]
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Updated { get; set; }
        [Name("KEY")]
        [Required]
        [MaxLength(200)]
        public string Key { get; set; }
        [Name("FREQ")]
        [Required]
        public char Frequency { get; set; }
        [Name("CURRENCY")]
        [Required]
        [MaxLength(10)]
        public string Currency { get; set; }
        [Name("CURRENCY_DENOM")]
        [Required]
        public string CurrencyDenomination { get; set; }
        [Name("EXR_TYPE")]
        [Required]
        [MaxLength(10)]
        public string ExchangeRateType { get; set; }
        [Name("EXR_SUFFIX")]
        [Required]
        public char ExchangeRateSuffix { get; set; }
        [Name("TIME_PERIOD")]
        [Required]
        [Column(TypeName = "Date")]
        public DateTime TimePeriod { get; set; }
        [Name("OBS_VALUE")]
        [Required]
        public decimal? Value { get; set; }
        [Name("OBS_STATUS")]
        [Required]
        public char Status { get; set; }
        [Name("OBS_CONF")]
        public string Confirmed { get; set; }
        [Name("OBS_PRE_BREAK")]
        [MaxLength(50)]
        public string ObsPreBreak { get; set; }

        [Name("OBS_COM")]
        [MaxLength(50)]
        public string ObsCom { get; set; }
        [Name("TIME_FORMAT")]
        [MaxLength(50)]
        public string TimeFormat { get; set; }
        [Name("SOURCE_AGENCY")]
        [MaxLength(200)]
        public string SourceAgency { get; set; }
        [Name("SOURCE_PUB")]
        [MaxLength(200)]
        public string SourcePublisher { get; set; }
        [Name("TITLE")]
        [MaxLength(200)]
        public string Title { get; set; }
        [Name("UNIT")]
        [MaxLength(10)]
        public string Unit { get; set; }
    }
}
