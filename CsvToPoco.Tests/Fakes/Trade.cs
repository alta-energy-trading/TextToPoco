using System;
using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CsvToPoco.Tests.Fakes
{
    [Table("Trade", Schema = "Kpler")]
    public class Trade
    {
        [Key]
        [Ignore]
        public long Id { get; set; }

        [Name("Vessel")]
        [Column("Vessel")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Vessel { get; set; }

        [Name("Vessel Name 2")]
        [Column("Vessel2")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Vessel2 { get; set; }

        [Name("Vessel Name 3")]
        [Column("Vessel3")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Vessel3 { get; set; }

        [Name("Vessel Name 4")]
        [Column("Vessel4")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Vessel4 { get; set; }

        [Name("Volume (bbl)")]
        [Column("VolumeBbl")]
        public long VolumeBbl { get; set; }

        [Name("Family")]
        [Column("Family")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Family { get; set; }

        [Name("Origin")]
        [Column("Origin")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Origin { get; set; }

        [Name("Country (origin)")]
        [Column("OriginCountry")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string OriginCountry { get; set; }

        [Name("Subcontinent (origin)")]
        [Column("OriginSubContinent")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string OriginSubContinent { get; set; }

        [Name("Continent Origin")]
        [Column("OriginContinent")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string OriginContinent { get; set; }

        [Name("Eta (origin)")]
        [Column("EtaOrigin")]
        public DateTime? EtaOrigin { get; set; }

        [Name("Start (origin)")]
        [Column("StartOrigin")]
        public DateTime? StartOrigin { get; set; }

        [Name("End (origin)")]
        [Column("EndOrigin")]
        public DateTime? EndOrigin { get; set; }

        [Name("Eta source (origin)")]
        [Column("OriginEtaSource")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string OriginEtaSource { get; set; }

        [Name("Reload STS Partial (origin)")]
        [Column("OriginReloadStsPartial")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string OriginReloadStsPartial { get; set; }

        [Name("Destination")]
        [Column("Destination")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Destination { get; set; }
        
        [Name("Country (destination)")]
        [Column("DestinationCountry")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string DestinationCountry { get; set; }

        [Name("Subcontinent (destination)")]
        [Column("DestinationSubContinent")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string DestinationSubContinent { get; set; }

        [Name("Continent Destination")]
        [Column("DestinationContinent")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string DestinationContinent { get; set; }

        [Name("Eta (destination)")]
        [Column("EtaDestination")]
        public DateTime? EtaDestination { get; set; }

        [Name("Start (destination)")]
        [Column("StartDestination")]
        public DateTime? StartDestination { get; set; }

        [Name("End (destination)")]
        [Column("EndDestination")]
        public DateTime? EndDestination { get; set; }

        [Name("Eta source (destination)")]
        [Column("DestinationEtaSource")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string DestinationEtaSource { get; set; }

        [Name("Reload STS Partial (destination)")]
        [Column("DestinationReloadStsPartial")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string DestinationReloadStsPartial { get; set; }

        [Name("Forecasted destination")]
        [Column("ForecastedDestination")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string ForecastedDestination { get; set; }

        [Name("Forecasted ETA")]
        [Column("ForecastedEta")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string ForecastedEta { get; set; }

        [Name("Forecasted confidence")]
        [Column("ForecastedConfidence")]
        public decimal? ForecastedConfidence { get; set; }

        [Name("Trade status")]
        [Column("TradeStatus")]
        public string TradeStatus { get; set; }

        [Name("Seller (origin)")]
        [Column("OriginSeller")]
        public string OriginSeller { get; set; }

        [Name("Buyer (destination)")]
        [Column("DestinationBuyer")]
        public string DestinationBuyer { get; set; }

        [Name("Intermediaries")]
        [Column("Intermediaries")]
        public int? Intermediaries { get; set; }

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

        [Name("Capacity (vessel m3)")]
        [Column("CapacityM3")]
        public long? CapacityM3 { get; set; }

        [Name("Cargo (tons)")]
        [Column("CargoTons")]
        public long? CargoTons { get; set; }

        [Name("Cargo Sources")]
        [Column("CargoSources")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string CargoSources { get; set; }

        [Name("Charterer")]
        [Column("Charterer")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Charterer { get; set; }

        [Name("Country STS 1")]
        [Column("CountrySTS1")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string CountrySTS1 { get; set; }

        [Name("Country STS 2")]
        [Column("CountrySTS2")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string CountrySTS2 { get; set; }

        [Name("Country STS 3")]
        [Column("CountrySTS3")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string CountrySTS3 { get; set; }

        [Name("Date (destination)")]
        [Column("DestinationDate")]
        public DateTime? DestinationDate { get; set; }

        [Name("Date (origin)")]
        [Column("OriginDate")]
        public DateTime? OriginDate { get; set; }

        [Name("Date End STS 1")]
        [Column("DateEndSTS1")]
        public DateTime? DateEndSTS1 { get; set; }

        [Name("Date End STS 2")]
        [Column("DateEndSTS2")]
        public DateTime? DateEndSTS2 { get; set; }

        [Name("Date End STS 3")]
        [Column("DateEndSTS3")]
        public DateTime? DateEndSTS3 { get; set; }

        [Name("Date Start STS 1")]
        [Column("DateStartSTS1")]
        public DateTime? DateStartSTS1 { get; set; }

        [Name("Date Start STS 2")]
        [Column("DateStartSTS2")]
        public DateTime? DateStartSTS2 { get; set; }

        [Name("Date Start STS 3")]
        [Column("DateStartSTS3")]
        public DateTime? DateStartSTS3 { get; set; }

        [Name("Cargo type (vessel)")]
        [Column("CargoType")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string CargoType { get; set; }

        [Name("Estimated Product - Confidence")]
        [Column("EstimatedProductConfidence")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string EstimatedProductConfidence { get; set; }

        [Name("Grade API")]
        [Column("API")]
        public double? API { get; set; }

        [Name("Export price")]
        [Column("ExportPrice")]
        public double? ExportPrice { get; set; }

        [Name("Forecasted origin")]
        [Column("ForecastedOrigin")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string ForecastedOrigin { get; set; }

        [Name("Forecasted origin ETA")]
        [Column("ForecastedOriginETA")]
        public DateTime? ForecastedOriginETA { get; set; }

        [Name("Forecasted origin confidence")]
        [Column("ForecastedOriginConfidence")]
        public double? ForecastedOriginConfidence { get; set; }

        [Name("Grade Sulfur")]
        [Column("Sulfur")]
        public double? Sulfur { get; set; }

        [Name("IMO (vessel)")]
        [Column("IMO")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string IMO { get; set; }

        [Name("Id (vessel)")]
        [Column("VesselId")]
        public long? VesselId { get; set; }

        [Name("Vessel Id 2")]
        [Column("VesselId2")]
        public long? VesselId2 { get; set; }

        [Name("Vessel Id 3")]
        [Column("VesselId3")]
        public long? VesselId3 { get; set; }

        [Name("Vessel Id 4")]
        [Column("VesselId4")]
        public long? VesselId4 { get; set; }

        [Name("Id (Trade)")]
        [Column("TradeId")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string TradeId { get; set; }

        [Name("Id (Voyage)")]
        [Column("VoyageId")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VoyageId { get; set; }

        [Name("Voyage Id 4")]
        [Column("VoyageId4")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VoyageId4 { get; set; }

        [Name("Voyage Id 2")]
        [Column("VoyageId2")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VoyageId2 { get; set; }

        [Name("Voyage Id 3")]
        [Column("VoyageId3")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VoyageId3 { get; set; }

        [Name("Zone Canal Transit")]
        [Column("ZoneCanalTransit")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string ZoneCanalTransit { get; set; }

        [Name("Zone STS 1")]
        [Column("ZoneSTS1")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string ZoneSTS1 { get; set; }

        [Name("Zone STS 2")]
        [Column("ZoneSTS2")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string ZoneSTS2 { get; set; }

        [Name("Zone STS 3")]
        [Column("ZoneSTS3")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string ZoneSTS3 { get; set; }

        [Name("Zone STS Id 1")]
        [Column("ZoneSTSId1")]
        public long? ZoneSTSId1 { get; set; }

        [Name("Zone STS Id 2")]
        [Column("ZoneSTSId2")]
        public long? ZoneSTSId2 { get; set; }

        [Name("Zone STS Id 3")]
        [Column("ZoneSTSId3")]
        public long? ZoneSTSId3 { get; set; }

        [Name("Id (Shipment)")]
        [Column("ShipmentId")]
        public long? ShipmentId { get; set; }

        [Name("Import price")]
        [Column("ImportPrice")]
        public double? ImportPrice { get; set; }

        [Name("Volume STS 1")]
        [Column("VolumeSTS1")]
        public double? VolumeSTS1 { get; set; }

        [Name("Volume STS 2")]
        [Column("VolumeSTS2")]
        public double? VolumeSTS2 { get; set; }

        [Name("Volume STS 3")]
        [Column("VolumeSTS3")]
        public double? VolumeSTS3 { get; set; }

        [Name("MMSI (vessel)")]
        [Column("MMSI")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string MMSI { get; set; }

        [Name("Installation STS 1")]
        [Column("InstallationSTS1")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string InstallationSTS1 { get; set; }

        [Name("Installation STS 2")]
        [Column("InstallationSTS2")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string InstallationSTS2 { get; set; }

        [Name("Installation STS 3")]
        [Column("InstallationSTS3")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string InstallationSTS3 { get; set; }

        [Name("Link1 buyer country")]
        [Column("Link1BuyerCountry")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link1BuyerCountry { get; set; }
        
        [Name("Link1 buyer name")]
        [Column("Link1BuyerName")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link1BuyerName { get; set; }

        [Name("Link1 delivery")]
        [Column("Link1Delivery")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link1Delivery { get; set; }

        [Name("Link1 seller country")]
        [Column("Link1SellerCountry")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link1SellerCountry { get; set; }

        [Name("Link1 seller name")]
        [Column("Link1SellerName")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link1SellerName { get; set; }

        [Name("Link1 type")]
        [Column("Link1Type")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link1Type { get; set; }

        [Name("Link2 buyer country")]
        [Column("Link2BuyerCountry")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link2BuyerCountry { get; set; }

        [Name("Link2 buyer name")]
        [Column("Link2BuyerName")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link2BuyerName { get; set; }

        [Name("Link2 delivery")]
        [Column("Link2Delivery")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link2Delivery { get; set; }

        [Name("Link2 seller country")]
        [Column("Link2SellerCountry")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link2SellerCountry { get; set; }

        [Name("Link2 seller name")]
        [Column("Link2SellerName")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link2SellerName { get; set; }

        [Name("Link2 type")]
        [Column("Link2Type")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link2Type { get; set; }

        [Name("Link3 buyer country")]
        [Column("Link3BuyerCountry")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link3BuyerCountry { get; set; }

        [Name("Link3 buyer name")]
        [Column("Link3BuyerName")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link3BuyerName { get; set; }

        [Name("Link3 delivery")]
        [Column("Link3Delivery")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link3Delivery { get; set; }

        [Name("Link3 seller country")]
        [Column("Link3SellerCountry")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link3SellerCountry { get; set; }

        [Name("Link3 seller name")]
        [Column("Link3SellerName")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link3SellerName { get; set; }

        [Name("Link3 type")]
        [Column("Link3Type")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link3Type { get; set; }

        [Name("Link4 buyer country")]
        [Column("Link4BuyerCountry")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link4BuyerCountry { get; set; }

        [Name("Link4 buyer name")]
        [Column("Link4BuyerName")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link4BuyerName { get; set; }

        [Name("Link4 delivery")]
        [Column("Link4Delivery")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link4Delivery { get; set; }

        [Name("Link4 seller country")]
        [Column("Link4SellerCountry")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link4SellerCountry { get; set; }

        [Name("Link4 seller name")]
        [Column("Link4SellerName")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link4SellerName { get; set; }

        [Name("Link4 type")]
        [Column("Link4Type")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link4Type { get; set; }

        [Name("Link5 buyer country")]
        [Column("Link5BuyerCountry")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link5BuyerCountry { get; set; }

        [Name("Link5 buyer name")]
        [Column("Link5BuyerName")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link5BuyerName { get; set; }

        [Name("Link5 delivery")]
        [Column("Link5Delivery")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link5Delivery { get; set; }

        [Name("Link5 seller country")]
        [Column("Link5SellerCountry")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link5SellerCountry { get; set; }

        [Name("Link5 seller name")]
        [Column("Link5SellerName")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link5SellerName { get; set; }

        [Name("Link5 type")]
        [Column("Link5Type")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string Link5Type { get; set; }

        [Name("Vessel Type Alternative ")]
        [Column("VesselTypeAlternative")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VesselTypeAlternative { get; set; }

        [Name("Vessel Type Alternative 2")]
        [Column("VesselTypeAlternative2")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VesselTypeAlternative2 { get; set; }

        [Name("Vessel Type Alternative 3")]
        [Column("VesselTypeAlternative3")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VesselTypeAlternative3 { get; set; }

        [Name("Vessel Type Alternative 4")]
        [Column("VesselTypeAlternative4")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VesselTypeAlternative4 { get; set; }

        [Name("Number of trades (export)")]
        [Column("ExportNumberOfTrades")]
        public long? ExportNumberOfTrades { get; set; }

        [Name("Number of trades (import)")]
        [Column("ImportNumberOfTrades")]
        public long? ImportNumberOfTrades { get; set; }

        [Name("Origin PortCall Id")]
        [Column("OriginPortCallId")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string OriginPortCallId { get; set; }

        [Name("Parent Id (Shipment)")]
        [Column("ShipmentParentId")]
        public long? ShipmentParentId { get; set; }

        [Name("Vessel DWT")]
        [Column("VesselDwt1")]
        public long? VesselDwt1 { get; set; }

        [Name("Vessel DWT 2")]
        [Column("VesselDwt2")]
        public long? VesselDwt2 { get; set; }

        [Name("Vessel DWT 3")]
        [Column("VesselDwt3")]
        public long? VesselDwt3 { get; set; }

        [Name("Vessel DWT 4")]
        [Column("VesselDwt4")]
        public long? VesselDwt4 { get; set; }

        [Name("Vessel type")]
        [Column("VesselType")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VesselType { get; set; }

        [Name("Vessel Type 2")]
        [Column("VesselType2")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VesselType2 { get; set; }

        [Name("Vessel Type 3")]
        [Column("VesselType3")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VesselType3 { get; set; }

        [Name("Vessel Type 4")]
        [Column("VesselType4")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VesselType4 { get; set; }

        [Name("Vessel IMO 2")]
        [Column("VesselIMO2")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VesselIMO2 { get; set; }

        [Name("Vessel IMO 3")]
        [Column("VesselIMO3")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VesselIMO3 { get; set; }

        [Name("Vessel IMO 4")]
        [Column("VesselIMO4")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string VesselIMO4 { get; set; }

        [Name("Zone Origin")]
        [Column("OriginZone")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string OriginZone { get; set; }

        [Name("Zone Origin Id")]
        [Column("OriginZoneId")]
        public long? OriginZoneId { get; set; }

        [Name("Zone Destination")]
        [Column("DestinationZone")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string DestinationZone { get; set; }

        [Name("Zone Destination Id")]
        [Column("DestinationZoneId")]
        public long? DestinationZoneId { get; set; }

        [Name("Installation origin")]
        [Column("OriginInstallation")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string OriginInstallation { get; set; }

        [Name("Installation origin id")]
        [Column("OriginInstallationId")]
        public long? OriginInstallationId { get; set; }

        [Name("Installation Destination")]
        [Column("DestinationInstallation")]
        [MaxLength(Constants.STRING_MEDIUM)]
        public string DestinationInstallation { get; set; }

        [Name("Installation Destination Id")]
        [Column("DestinationInstallationId")]
        public long? DestinationInstallationId { get; set; }

        [Name("Mileage")]
        [Column("Mileage")]
        public long? Mileage { get; set; }

        [Name("Ton Miles")]
        [Column("TonMiles")]
        public long? TonMiles { get; set; }
    }
}
