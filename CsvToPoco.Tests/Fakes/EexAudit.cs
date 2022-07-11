using CsvHelper.Configuration.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsvToPoco.Tests.Fakes
{
    [Table("EexAudit", Schema = "tt")]
    public class EexAudit
    {
        [Ignore]
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Ignore]
        public string FileName { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string MessageType { get; set; }
        public string TTOrderID { get; set; }
        public string TTInstrumentID { get; set; }
        public string ProductType { get; set; }
        public string ProductSymbol { get; set; }
        [Column(TypeName = "date")]
        public DateTime MaturityDate { get; set; }
        public int TTRequestID { get; set; }
        public string ExchangeRequestID { get; set; }
        public string ExchangeOrderID { get; set; }
        public int ExchangeLinkAssociation { get; set; }
        public string OrderType { get; set; }
        public string TimeInForce { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ExpireDate { get; set; }
        public string ExecutionType { get; set; }
        public string OrderStatus { get; set; }
        public string Text { get; set; }
        public string RejectSource { get; set; }
        public string Side { get; set; }
        public int OrderQty { get; set; }
        public int CumQty { get; set; }
        public int LeavesQty { get; set; }
        public string MinQty { get; set; }
        public int? LastQty { get; set; }
        public string DisplayQty { get; set; }
        public string RefreshQty { get; set; }
        public int ExchangeOrderQty { get; set; }
        public int ExchangeLeavesQty { get; set; }
        public int ExchangeCumQty { get; set; }
        public double Price { get; set; }
        public double? LastPrice { get; set; }
        public string StopPrice { get; set; }
        public string ExecutionID { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TradeDate { get; set; }
        public string Account { get; set; }
        public int SenderSubID { get; set; }
        public int TTConnectionID { get; set; }
        public string SecurityRequestID { get; set; }
        public string SecurityDefinitionStatus { get; set; }
        public int TTUserID { get; set; }
        public int TTAccountID { get; set; }
        public int UserID { get; set; }
        public string TakeUpMember { get; set; }
        public string ExchangeAccount { get; set; }
        public string Text1 { get; set; }
        public string Text3 { get; set; }
        public string AccountCode { get; set; }
        public string ComplianceID { get; set; }
        public string QuoteRequestID { get; set; }
        public string QuoteStatus { get; set; }
        public string Headline { get; set; }
        public string TTCurrentUserID { get; set; }
        public string IPAddress { get; set; }
        public string DirectElectronicAccess { get; set; }
        public string TradingCapacity { get; set; }
        public int LiquidityProvision { get; set; }
        public int CommodityDerivIndicator { get; set; }
        public string InvestmentDecision { get; set; }
        public string InvestmentDecisionIsAlgo { get; set; }
        public int? ExecutionDecision { get; set; }
        public string ExecutionDecisionIsAlgo { get; set; }
        public int ClientIDCode { get; set; }
        public string CustomerDefinedClientIDCode { get; set; }
        public string TVTIC { get; set; }
        public string TTFIXClientOrderID { get; set; }
        public string TTFIXOriginalClientOrderID { get; set; }
        public string TTExecutionID { get; set; }
        public string ExchangeLatency { get; set; }
        [Column(TypeName = "date")]
        public DateTime? PromptDate { get; set; }
    }
}
