using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = CsvHelper.Configuration.Attributes.IndexAttribute;

#nullable disable

namespace CsvToPoco.Tests.Fakes
{
    [Keyless]
    [Table("Movement")]
    public class Movement
    {
        [StringLength(50)]
        [Ignore]
        public string FileName { get; set; }

        [Ignore]
        [Required]
        [Column("query")]
        [StringLength(255)]
        public string Query { get; set; }
        [Index(0)]
        [Column("tanker_name")]
        [StringLength(255)]
        public string TankerName { get; set; }
        [Column("tanker_imo")]
        [StringLength(255)]
        [Index(1)]
        public string TankerImo { get; set; }
        [Column("tanker_dwt")]
        [Index(2)]
        public int? TankerDwt { get; set; }
        [Column("tanker_flag")]
        [StringLength(255)]
        [Index(3)]
        public string TankerFlag { get; set; }
        [Column("tanker_owner")]
        [StringLength(255)]
        [Index(4)]
        public string TankerOwner { get; set; }
        [Column("load_port_date", TypeName = "Date")]
        [StringLength(255)]
        [Index(5)]
        public DateTime LoadPortDate { get; set; }
        [Column("load_terminal")]
        [StringLength(255)]
        [Index(6)]
        public string LoadTerminal { get; set; }
        [Column("load_port")]
        [StringLength(255)]
        [Index(7)]
        public string LoadPort { get; set; }
        [Column("load_country")]
        [StringLength(255)]
        [Index(8)]
        public string LoadCountry { get; set; }
        [Column("report_group")]
        [StringLength(255)]
        [Index(9)]
        public string ReportGroup { get; set; }
        [Column("load_port_area")]
        [StringLength(255)]
        [Index(10)]
        public string LoadPortArea { get; set; }
        [Column("qty_tonnes")]
        [Index(11)]
        public int? QtyTonnes { get; set; }
        [Column("qty_barrels")]
        [Index(12)]
        public int? QtyBarrels { get; set; }
        [Column("c_f")]
        [StringLength(255)]
        [Index(13)]
        public string CF { get; set; }
        [Column("cargo_type")]
        [StringLength(255)]
        [Index(14)]
        public string CargoType { get; set; }
        [Column("cargo_grade")]
        [StringLength(255)]
        [Index(15)]
        public string CargoGrade { get; set; }
        [Column("grade_confidence")]
        [Index(16)]
        public int? GradeConfidence { get; set; }
        [Column("pc")]
        [StringLength(255)]
        [Index(17)]
        public string Pc { get; set; }
        [Column("discharge_port_date")]
        [StringLength(255)]
        [Index(18)]
        public string DischargePortDate { get; set; }
        [Column("discharge_port")]
        [StringLength(255)]
        [Index(19)]
        public string DischargePort { get; set; }
        [Column("second_discharge_port")]
        [StringLength(255)]
        [Index(20)]
        public string SecondDischargePort { get; set; }
        [Column("via")]
        [StringLength(255)]
        [Index(21)]
        public string Via { get; set; }
        [Column("discharge_country")]
        [StringLength(255)]
        [Index(22)]
        public string DischargeCountry { get; set; }
        [Column("discharge_area")]
        [StringLength(255)]
        [Index(23)]
        public string DischargeArea { get; set; }
        [Column("supplier")]
        [StringLength(255)]
        [Index(24)]
        public string Supplier { get; set; }
        [Column("middle_man")]
        [StringLength(255)]
        [Index(25)]
        public string MiddleMan { get; set; }
        [Column("customer")]
        [StringLength(255)]
        [Index(26)]
        public string Customer { get; set; }
        [Column("company_confidence")]
        [Index(27)]
        public int? CompanyConfidence { get; set; }

        [Column("supplier_note")]
        [Index(28)]
        public string SupplierNote { get; set; }
        [Column("customer_note")]
        [Index(29)]
        public string CustomerNote { get; set; }
        [Column("note")]
        [Index(30)]
        public string Note { get; set; }
        [Column("quality_category")]
        [StringLength(255)]
        [Index(31)]
        public string QualityCategory { get; set; }
        [Index(32)]
        [Column("load_week")]
        [StringLength(25)]
        public string LoadWeek { get; set; }
        [Column("load_weekyear")]
        [StringLength(25)]
        [Index(33)]
        public string LoadWeekyear { get; set; }
        [Column("load_month")]
        [StringLength(25)]
        [Index(34)]
        public string LoadMonth { get; set; }
        [Column("load_quarter")]
        [StringLength(25)]
        [Index(35)]
        public string LoadQuarter { get; set; }
        [Column("load_year")]
        [Index(36)]
        public int? LoadYear { get; set; }
        [Column("discharge_week")]
        [StringLength(25)]
        [Index(37)]
        public string DischargeWeek { get; set; }
        [Column("discharge_weekyear")]
        [StringLength(25)]
        [Index(38)]
        public string DischargeWeekyear { get; set; }
        [Column("discharge_month")]
        [StringLength(25)]
        [Index(39)]
        public string DischargeMonth { get; set; }
        [Column("discharge_quarter")]
        [StringLength(25)]
        [Index(40)]
        public string DischargeQuarter { get; set; }
        [Column("discharge_year")]
        [Index(41)]
        public int? DischargeYear { get; set; }
        [Column("transit_time")]
        [StringLength(25)]
        [Index(42)]
        public string TransitTime { get; set; }
        [Column("cargo_id")]
        [Index(43)]
        public long CargoId { get; set; }
        [Column("client_cargo_status")]
        [Index(44)]
        public int? ClientCargoStatus { get; set; }
        [Ignore]
        [StringLength(50)]
        public string MovementHash { get; set; }
    }
}
