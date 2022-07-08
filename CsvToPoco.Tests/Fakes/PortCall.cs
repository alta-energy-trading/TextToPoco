using System;
using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CsvToPoco
{
    [Table("PortCall", Schema = "Kpler")]
    public class PortCall
    {
        [Name("Vessel")]
        [Column("Vessel")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Vessel { get; set; }

        [Name("Installation")]
        [Column("Installation")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Installation { get; set; }

        [Name("ETA")]
        [Column("Eta")]
        public DateTime? Eta { get; set; }

        [Name("Start")]
        [Column("Start")]
        public DateTime? Start { get; set; }

        [Name("End")]
        [Column("End")]
        public DateTime? End { get; set; }

        [Name("Volume (bbl)")]
        [Column("VolumeBbl")]
        public long? VolumeBbl { get; set; }

        [Name("Family")]
        [Column("Family")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Family { get; set; }

        [Name("Group")]
        [Column("Group")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Group { get; set; }

        [Name("Product")]
        [Column("Product")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Product { get; set; }

        [Name("Grade")]
        [Column("Grade")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Grade { get; set; }

        [Name("Capacity (m3)")]
        [Column("CapacityM3")]
        public long? CapacityM3 { get; set; }

        [Name("Cargo (tons)")]
        [Column("CargoTons")]
        public long? CargoTons { get; set; }

        [Name("Cargo type (vessel)")]
        [Column("CargoType")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string CargoType { get; set; }

        [Name("Charterer")]
        [Column("Charterer")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Charterer { get; set; }

        [Name("Confidence")]
        [Column("Confidence")]
        public long? Confidence { get; set; }

        [Name("Continent")]
        [Column("Continent")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Continent { get; set; }

        [Name("Country")]
        [Column("Country")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Country { get; set; }

        [Name("Forecasted")]
        [Column("Forecasted")]
        public bool? Forecasted { get; set; }

        [Name("Grade API")]
        [Column("API")]
        public double? API { get; set; }

        [Name("Grade Sulfur")]
        [Column("Sulfur")]
        public double? Sulfur { get; set; }

        [Name("IMO (vessel)")]
        [Column("IMO")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string IMO { get; set; }

        [Name("Id (installation)")]
        [Column("InstallationId")]
        public long? InstallationId { get; set; }

        [Name("Id (portCall)")]
        [Column("PortCallId")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string PortCallId { get; set; }

        [Name("Id (vessel)")]
        [Column("VesselId")]
        public long? VesselId { get; set; }

        [Name("Id (voyage)")]
        [Column("VoyageId")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VoyageId { get; set; }

        [Name("Id (zone)")]
        [Column("ZoneId")]
        public long? ZoneId { get; set; }

        [Name("Location")]
        [Column("Location")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Location { get; set; }

        [Name("MMSI (vessel)")]
        [Column("MMSI")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string MMSI { get; set; }

        [Name("PartialCargo")]
        [Column("PartialCargo")]
        public bool? PartialCargo { get; set; }

        [Name("Reexport")]
        [Column("Reexport")]
        public bool? Reexport { get; set; }

        [Name("Ship to ship")]
        [Column("ShipToShip")]
        public bool? ShipToShip { get; set; }

        [Name("Status (installation)")]
        [Column("InstallationStatus")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string InstallationStatus { get; set; }

        [Name("Storage capacity (installation)")]
        [Column("InstallationStorageCapacity")]
        public long? InstallationStorageCapacity { get; set; }

        [Name("SubContinent")]
        [Column("SubContinent")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string SubContinent { get; set; }

        [Name("Type (installation)")]
        [Column("InstallationType")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string InstallationType { get; set; }

        [Name("Vessel Type Alternative")]
        [Column("VesselTypeAlternative")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VesselTypeAlternative { get; set; }

        [Name("Vessel type")]
        [Column("VesselType")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VesselType { get; set; }

        [Name("Volume (m3)")]
        [Column("VolumeM3")]
        public double? VolumeM3 { get; set; }

        [Name("zone")]
        [Column("Zone")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Zone { get; set; }
    }
}
