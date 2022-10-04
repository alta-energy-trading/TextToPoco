using CsvHelper.Configuration.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsvToPoco.Tests.Fakes
{
    [Table("RawFill", Schema = "TT")]
    public class RawFill
    {
        [Ignore]
        [Key]
        public int Id { get; set; }
        [Ignore]
        public string FileName { get; set; }
        public DateTime Time { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public string Account { get; set; }
        public string Contract { get; set; }
        public string Product { get; set; }
        public string Originator { get; set; }
        public string CurrentUser { get; set; }
        public float Price { get; set; }
        public int PriceInTicks { get; set; }
        public float? TrigPrc { get; set; }
        public long? TrigPrcInTicks { get; set; }
        public int FillQty { get; set; }
        public int WorkQty { get; set; }
        public int ExeQty { get; set; }
        public string ExchOrderID { get; set; }
        public string ExchTransID { get; set; }
        public string ClOrderID { get; set; }
        public string TTOrderID { get; set; }
        public string ParentID { get; set; }
        public string FillType { get; set; }
        public string Strike { get; set; }
        public char DEA { get; set; }
        [Column(TypeName = "date")]
        public DateTime ExchDate { get; set; }
        public string PF { get; set; }
        public int ConnectionID { get; set; }
        public string Type { get; set; }
        public string PC { get; set; }
        public char PA { get; set; }
        public DateTime ExchTime { get; set; }
        public string OC { get; set; }
        public string ExchAcct { get; set; }
        public string Route { get; set; }
        public string ManualFill { get; set; }
        public string TrdgCap { get; set; }
        public string OMAOrderID { get; set; }
        public string Confirmed { get; set; }
        public string Exchange { get; set; }
        public string BS { get; set; }
        public string ProdType { get; set; }
        public string Broker { get; set; }
        public string InvestDec { get; set; }
        public string ExecDec { get; set; }
        public float LiqProv { get; set; }
        public float CDI { get; set; }
        public string GiveUp { get; set; }
        public int Client { get; set; }
        public string Modifier { get; set; }
        public string TextA { get; set; }
        public string TextB { get; set; }
        public string TextTT { get; set; }
        public string TimeSent { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DealDate { get; set; }
        public DateTime? DealTime { get; set; }
        public string CounterParty { get; set; }
        public string AlgoName { get; set; }
        public string TrdMbr { get; set; }
        public string TrdGrp { get; set; }
        public string ExchTrd { get; set; }
        public string AcctType { get; set; }
        [Column(TypeName = "date")]
        public DateTime OriginalDate { get; set; }
        public DateTime OriginalTime { get; set; }
        public string SharedAccountName { get; set; }
        public string Term { get; set; }
        public string SecondaryClient { get; set; }
        public string SecondaryExecutionDecisionMaker { get; set; }
        public string ComplianceText { get; set; }
        public string InvestDecQ { get; set; }
        public string ExecDecQ { get; set; }
        [Column(TypeName = "date")]
        public DateTime MaturityDate { get; set; }
        public string Expiry { get; set; }
        public string InstrumentID { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ClearingDate { get; set; }
        public string OrderProfile { get; set; }
    }
}