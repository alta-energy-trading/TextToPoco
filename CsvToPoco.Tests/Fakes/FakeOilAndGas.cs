using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration.Attributes;
using CsvToPoco.CustomTypeConverters;

namespace CsvToPoco.Tests.Fakes
{
    [Table("OilAndGas", Schema = "Rystad")]
    public class FakeOilAndGas
    {
        [Key]
        public int Id { get; set; }
        [Column("API_Average")]
        [Name("API Average")]
        [TypeConverter(typeof(StringToNullableIntConverter))]
        public int? ApiAverage { get; set; }
        [Required]
        [Column("API_Category")]
        [StringLength(50)]
        [Name("API Category")]
        public string ApiCategory { get; set; }
        [Required]
        [Column("API_Group")]
        [StringLength(50)]
        [Name("API Group")]
        public string ApiGroup { get; set; }
        [Required]
        [Column("Oil_and_Gas_Category")]
        [StringLength(50)]
        [Name("Oil and Gas Category")]
        public string OilAndGasCategory { get; set; }
    }
}
