using CsvHelper.Configuration;

namespace CsvToPoco.Tests.Fakes.ClassMaps
{
    public class RawFillClassMap : ClassMap<RawFill>
    {
        public RawFillClassMap()
        {
            Map(m => m.Time).Name("Time").TypeConverter<ReducePrecisionDateTimeConverter>();
            Map(m => m.Date).Name("Date");
            Map(m => m.Account).Name("Account");
            Map(m => m.Contract).Name("Contract");
            Map(m => m.Product).Name("Product");
            Map(m => m.Originator).Name("Originator");
            Map(m => m.CurrentUser).Name("CurrentUser");
            Map(m => m.Price).Name("Price");
            Map(m => m.PriceInTicks).Name("PriceInTicks");
            Map(m => m.TrigPrc).Name("TrigPrc");
            Map(m => m.TrigPrcInTicks).Name("TrigPrcInTicks");
            Map(m => m.FillQty).Name("FillQty");
            Map(m => m.WorkQty).Name("WorkQty");
            Map(m => m.ExeQty).Name("ExeQty");
            Map(m => m.ExchOrderID).Name("ExchOrderID");
            Map(m => m.ExchTransID).Name("ExchTransID");
            Map(m => m.ClOrderID).Name("ClOrderID");
            Map(m => m.TTOrderID).Name("TTOrderID");
            Map(m => m.ParentID).Name("ParentID");
            Map(m => m.FillType).Name("Fill Type");
            Map(m => m.Strike).Name("Strike");
            Map(m => m.DEA).Name("D.E.A.");
            Map(m => m.ExchDate).Name("ExchDate");
            Map(m => m.PF).Name("P/F");
            Map(m => m.ConnectionID).Name("ConnectionID");
            Map(m => m.Type).Name("Type");
            Map(m => m.PC).Name("P/C");
            Map(m => m.PA).Name("P/A");
            Map(m => m.ExchTime).Name("ExchTime").TypeConverter<ReducePrecisionDateTimeConverter>();
            Map(m => m.OC).Name("O/C");
            Map(m => m.ExchAcct).Name("ExchAcct");
            Map(m => m.Route).Name("Route");
            Map(m => m.ManualFill).Name("ManualFill");
            Map(m => m.TrdgCap).Name("TrdgCap");
            Map(m => m.OMAOrderID).Name("OMAOrderID");
            Map(m => m.Confirmed).Name("Confirmed");
            Map(m => m.Exchange).Name("Exchange");
            Map(m => m.BS).Name("B/S");
            Map(m => m.ProdType).Name("Prod Type");
            Map(m => m.Broker).Name("Broker");
            Map(m => m.InvestDec).Name("InvestDec");
            Map(m => m.ExecDec).Name("ExecDec");
            Map(m => m.LiqProv).Name("LiqProv");
            Map(m => m.CDI).Name("C.D.I");
            Map(m => m.GiveUp).Name("GiveUp");
            Map(m => m.Client).Name("Client");
            Map(m => m.Modifier).Name("Modifier");
            Map(m => m.TextA).Name("TextA");
            Map(m => m.TextB).Name("TextB");
            Map(m => m.TextTT).Name("TextTT");
            Map(m => m.TimeSent).Name("TimeSent");
            Map(m => m.DealDate).Name("DealDate");
            Map(m => m.DealTime).Name("DealTime").TypeConverter<ReducePrecisionDateTimeConverter>();
            Map(m => m.CounterParty).Name("CounterParty");
            Map(m => m.AlgoName).Name("AlgoName");
            Map(m => m.TrdMbr).Name("Trd Mbr");
            Map(m => m.TrdGrp).Name("Trd Grp");
            Map(m => m.ExchTrd).Name("Exch Trd");
            Map(m => m.AcctType).Name("AcctType");
            Map(m => m.OriginalDate).Name("OriginalDate");
            Map(m => m.OriginalTime).Name("OriginalTime").TypeConverter<ReducePrecisionDateTimeConverter>();
            Map(m => m.SharedAccountName).Name("SharedAccountName");
            Map(m => m.Term).Name("Term");
            Map(m => m.SecondaryClient).Name("SecondaryClient");
            Map(m => m.SecondaryExecutionDecisionMaker).Name("SecondaryExecutionDecisionMaker");
            Map(m => m.ComplianceText).Name("ComplianceText");
            Map(m => m.InvestDecQ).Name("InvestDecQ");
            Map(m => m.ExecDecQ).Name("ExecDecQ");
            Map(m => m.MaturityDate).Name("MaturityDate");
            Map(m => m.Expiry).Name("Expiry");
            Map(m => m.InstrumentID).Name("InstrumentID");
            Map(m => m.ClearingDate).Name("ClearingDate");
            Map(m => m.OrderProfile).Name("OrderProfile");
        }
    }
}