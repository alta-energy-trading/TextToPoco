using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace CsvToPoco.Tests.Fakes
{
    [Table("CmeAudit", Schema = "tt")]
    public class CmeAudit
    {
        [Ignore]
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Ignore]
        public string FileName { get; set; }
        public DateTime? SendingTimestamps { get; set; }
        public DateTime? ReceivingTimestamps { get; set; }
        public string MessageDirection { get; set; }
        public string OperatorID { get; set; }
        public string SelfMatchPreventionID { get; set; }
        public string AccountNumber { get; set; }
        public string SessionID { get; set; }
        public string ExecutingFirmID { get; set; }
        public string ManualOrderIdentifier { get; set; }
        public string MessageType { get; set; }
        public string CustomerTypeIndicator { get; set; }
        public int? Origin { get; set; }
        public string CMEGlobexMessageID { get; set; }
        public string MessageLinkID { get; set; }
        public string OrderFlowID { get; set; }
        public string SpreadLegLinkID { get; set; }
        public string InstrumentDescription { get; set; }
        public int MarketSegmentID { get; set; }
        public string ClientOrderID { get; set; }
        public string CMEGlobexOrderID { get; set; }
        public int? BuySellIndicator { get; set; }
        public double? Quantity { get; set; }
        public double? LimitPrice { get; set; }
        public double? StopPrice { get; set; }
        public int? OrderType { get; set; }
        public int? OrderQualifier { get; set; }
        public string IFMFlag { get; set; }
        public string DisplayQuantity { get; set; }
        public double? MinimumQuantity { get; set; }
        public string CountryofOrigin { get; set; }
        public double? FillPrice { get; set; }
        public int? FillQuantity { get; set; }
        public int? CumulativeQuantity { get; set; }
        public int? RemainingQuantity { get; set; }
        public string AggressorFlag { get; set; }
        public string SourceofCancellation { get; set; }
        public string RejectReason { get; set; }
        public string ProcessedQuotes { get; set; }
        public string CrossID { get; set; }
        public string QuoteRequestID { get; set; }
        public string MessageQuoteID { get; set; }
        public string QuoteEntryID { get; set; }
        public double? BidPrice { get; set; }
        public double? BidSize { get; set; }
        public double? OfferPrice { get; set; }
        public double? OfferSize { get; set; }
        public int ProductInstrumentGroupCode { get; set; }
        public string ExchangeCode { get; set; }
        public int TTUserID { get; set; }
        public int TTCurrentUserID { get; set; }
        public string TTFIXClientOrderID { get; set; }
        public string TTFIXOriginalClientOrderID { get; set; }
        public string TTOrderID { get; set; }
        public int TTAccountID { get; set; }
        public string TTInstrumentID { get; set; }
    }
}
