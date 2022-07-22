using CsvHelper.Configuration;
using System;

namespace CsvToPoco.Tests.Fakes.ClassMaps
{
    public class EexAuditClassMap : ClassMap<EexAudit>
    {
        public EexAuditClassMap()
        {
            Map(m => m.Date).Name("Date");
            Map(m => m.Time).Name("Time").TypeConverter<ReducePrecisionDateTimeConverter>();
            Map(m => m.MessageType).Name("Message Type");
            Map(m => m.TTOrderID).Name("TT Order ID");
            Map(m => m.TTInstrumentID).Name("TT Instrument ID");
            Map(m => m.ProductType).Name("Product Type");
            Map(m => m.ProductSymbol).Name("Product Symbol");
            Map(m => m.MaturityDate).Name("Maturity Date");
            Map(m => m.TTRequestID).Name("TT Request ID");
            Map(m => m.ExchangeRequestID).Name("Exchange Request ID");
            Map(m => m.ExchangeOrderID).Name("Exchange Order ID");
            Map(m => m.ExchangeLinkAssociation).Name("Exchange Link Association");
            Map(m => m.OrderType).Name("Order Type");
            Map(m => m.TimeInForce).Name("Time In Force");
            Map(m => m.ExpireDate).Name("Expire Date");
            Map(m => m.ExecutionType).Name("Execution Type");
            Map(m => m.OrderStatus).Name("Order Status");
            Map(m => m.Text).Name("Text");
            Map(m => m.RejectSource).Name("Reject Source");
            Map(m => m.Side).Name("Side");
            Map(m => m.OrderQty).Name("Order Qty");
            Map(m => m.CumQty).Name("Cum Qty");
            Map(m => m.LeavesQty).Name("Leaves Qty");
            Map(m => m.MinQty).Name("Min Qty");
            Map(m => m.LastQty).Name("Last Qty");
            Map(m => m.DisplayQty).Name("Display Qty");
            Map(m => m.RefreshQty).Name("Refresh Qty");
            Map(m => m.ExchangeOrderQty).Name("Exchange Order Qty");
            Map(m => m.ExchangeLeavesQty).Name("Exchange Leaves Qty");
            Map(m => m.ExchangeCumQty).Name("Exchange Cum Qty");
            Map(m => m.Price).Name("Price");
            Map(m => m.LastPrice).Name("Last Price");
            Map(m => m.StopPrice).Name("Stop Price");
            Map(m => m.ExecutionID).Name("Execution ID");
            Map(m => m.TradeDate).Name("Trade Date");
            Map(m => m.Account).Name("Account");
            Map(m => m.SenderSubID).Name("Sender Sub ID");
            Map(m => m.TTConnectionID).Name("TT Connection ID");
            Map(m => m.SecurityRequestID).Name("Security Request ID");
            Map(m => m.SecurityDefinitionStatus).Name("Security Definition Status");
            Map(m => m.TTUserID).Name("TT User ID");
            Map(m => m.TTAccountID).Name("TT Account ID");
            Map(m => m.UserID).Name("User ID");
            Map(m => m.TakeUpMember).Name("Take Up Member");
            Map(m => m.ExchangeAccount).Name("Exchange Account");
            Map(m => m.Text1).Name("Text 1");
            Map(m => m.Text3).Name("Text 3");
            Map(m => m.AccountCode).Name("Account Code");
            Map(m => m.ComplianceID).Name("ComplianceID");
            Map(m => m.QuoteRequestID).Name("Quote Request ID");
            Map(m => m.QuoteStatus).Name("Quote Status");
            Map(m => m.Headline).Name("Headline");
            Map(m => m.TTCurrentUserID).Name("TT Current User ID");
            Map(m => m.IPAddress).Name("IP Address");
            Map(m => m.DirectElectronicAccess).Name("DirectElectronicAccess");
            Map(m => m.TradingCapacity).Name("TradingCapacity");
            Map(m => m.LiquidityProvision).Name("LiquidityProvision");
            Map(m => m.CommodityDerivIndicator).Name("CommodityDerivIndicator");
            Map(m => m.InvestmentDecision).Name("InvestmentDecision");
            Map(m => m.InvestmentDecisionIsAlgo).Name("InvestmentDecisionIsAlgo");
            Map(m => m.ExecutionDecision).Name("ExecutionDecision");
            Map(m => m.ExecutionDecisionIsAlgo).Name("ExecutionDecisionIsAlgo");
            Map(m => m.ClientIDCode).Name("ClientIDCode");
            Map(m => m.CustomerDefinedClientIDCode).Name("CustomerDefinedClientIDCode");
            Map(m => m.TVTIC).Name("TV TIC");
            Map(m => m.TTFIXClientOrderID).Name("TT FIX Client Order ID");
            Map(m => m.TTFIXOriginalClientOrderID).Name("TT FIX Original Client Order ID");
            Map(m => m.TTExecutionID).Name("TT Execution ID");
            Map(m => m.ExchangeLatency).Name("Exchange Latency");
            Map(m => m.PromptDate).Name("Prompt Date");
        }
    }
}
