using CsvHelper.Configuration;

namespace CsvToPoco.Tests.Fakes.ClassMaps
{ 
    public class CmeAuditClassMap : ClassMap<CmeAudit>
    {
        public CmeAuditClassMap()
        {
            Map(m => m.SendingTimestamps).Name("Sending Timestamps").TypeConverterOption.Format("yyyyMMdd-HH:mm:ss.fff", " yyyyMMdd - HH:mm:ss.fff", "yyyyMMdd - HH:mm:ss.fff");
            Map(m => m.ReceivingTimestamps).Name("Receiving Timestamps").TypeConverterOption.Format("yyyyMMdd-HH:mm:ss.fff", " yyyyMMdd - HH:mm:ss.fff", "yyyyMMdd - HH:mm:ss.fff");
            Map(m => m.MessageDirection).Name("Message Direction");
            Map(m => m.OperatorID).Name("Operator ID");
            Map(m => m.SelfMatchPreventionID).Name("Self-Match Prevention ID");
            Map(m => m.AccountNumber).Name("Account Number");
            Map(m => m.SessionID).Name("Session ID");
            Map(m => m.ExecutingFirmID).Name("Executing Firm ID");
            Map(m => m.ManualOrderIdentifier).Name("Manual Order Identifier");
            Map(m => m.MessageType).Name("Message Type");
            Map(m => m.CustomerTypeIndicator).Name("Customer Type Indicator");
            Map(m => m.Origin).Name("Origin").TypeConverter(new SpaceReplacerInt32Converter());
            Map(m => m.CMEGlobexMessageID).Name("CME Globex Message ID");
            Map(m => m.MessageLinkID).Name("Message Link ID");
            Map(m => m.OrderFlowID).Name("Order Flow ID");
            Map(m => m.SpreadLegLinkID).Name("Spread/Leg Link ID");
            Map(m => m.InstrumentDescription).Name("Instrument Description");
            Map(m => m.MarketSegmentID).Name("Market Segment ID");
            Map(m => m.ClientOrderID).Name("Client Order ID");
            Map(m => m.CMEGlobexOrderID).Name("CME Globex Order ID");
            Map(m => m.BuySellIndicator).Name("Buy/Sell Indicator").TypeConverter(new SpaceReplacerInt32Converter());
            Map(m => m.Quantity).Name("Quantity").TypeConverter(new SpaceReplacerDoubleConverter());
            Map(m => m.LimitPrice).Name("Limit Price").TypeConverter(new SpaceReplacerDoubleConverter());
            Map(m => m.StopPrice).Name("Stop Price").TypeConverter(new SpaceReplacerDoubleConverter());
            Map(m => m.OrderType).Name("Order Type").TypeConverter(new SpaceReplacerInt32Converter());
            Map(m => m.OrderQualifier).Name("Order Qualifier").TypeConverter(new SpaceReplacerInt32Converter());
            Map(m => m.IFMFlag).Name("IFM Flag");
            Map(m => m.DisplayQuantity).Name("Display Quantity");
            Map(m => m.MinimumQuantity).Name("Minimum Quantity").TypeConverter(new SpaceReplacerDoubleConverter());
            Map(m => m.CountryofOrigin).Name("Country of Origin");
            Map(m => m.FillPrice).Name("Fill Price").TypeConverter(new SpaceReplacerDoubleConverter());
            Map(m => m.FillQuantity).Name("Fill Quantity").TypeConverter(new SpaceReplacerInt32Converter());
            Map(m => m.CumulativeQuantity).Name("Cumulative Quantity").TypeConverter(new SpaceReplacerInt32Converter());
            Map(m => m.RemainingQuantity).Name("Remaining Quantity").TypeConverter(new SpaceReplacerInt32Converter());
            Map(m => m.AggressorFlag).Name("Aggressor Flag");
            Map(m => m.SourceofCancellation).Name("Source of Cancellation");
            Map(m => m.RejectReason).Name("Reject Reason");
            Map(m => m.ProcessedQuotes).Name("Processed Quotes");
            Map(m => m.CrossID).Name("Cross ID");
            Map(m => m.QuoteRequestID).Name("Quote Request ID");
            Map(m => m.MessageQuoteID).Name("Message Quote ID");
            Map(m => m.QuoteEntryID).Name("Quote Entry ID");
            Map(m => m.BidPrice).Name("Bid Price").TypeConverter(new SpaceReplacerDoubleConverter());
            Map(m => m.BidSize).Name("Bid Size").TypeConverter(new SpaceReplacerDoubleConverter());
            Map(m => m.OfferPrice).Name("Offer Price").TypeConverter(new SpaceReplacerDoubleConverter());
            Map(m => m.OfferSize).Name("Offer Size").TypeConverter(new SpaceReplacerDoubleConverter());
            Map(m => m.ProductInstrumentGroupCode).Name("Product/Instrument Group Code");
            Map(m => m.ExchangeCode).Name("Exchange Code");
            Map(m => m.TTUserID).Name("TT User ID");
            Map(m => m.TTCurrentUserID).Name("TT Current User ID");
            Map(m => m.TTFIXClientOrderID).Name("TT FIX Client Order ID");
            Map(m => m.TTFIXOriginalClientOrderID).Name("TT FIX Original Client Order ID");
            Map(m => m.TTOrderID).Name("TT Order ID");
            Map(m => m.TTAccountID).Name("TT Account ID");
            Map(m => m.TTInstrumentID).Name("TT Instrument ID");
        }
    }
}
