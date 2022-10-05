using CsvToPoco.Tests.Fakes;
using CsvToPoco.Tests.Fakes.ClassMaps;
using System.IO;
using System.Linq;
using CsvToPoco;
using Xunit;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace CsvToPoco.Tests
{
    public class ObjectifierTests
    {

        [Fact]
        public void Can_Deserialize()
        {
            Objectifier sut = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("Forecasted;Confidence;Id (portCall);Vessel;Location;Installation;zone;Country;ETA;Start;End;Family;Group;Product;Grade;Volume (m3);Volume (bbl);Cargo (tons);Charterer;Reexport;PartialCargo;Ship to ship;IMO (vessel);MMSI (vessel);Capacity (m3);Cargo type (vessel);Vessel type;Id (vessel);Id (installation);Id (zone);Type (installation);SubContinent;Continent;Storage capacity (installation);Status (installation);Id (voyage);Grade API;Grade Sulfur;Vessel Type Alternative\n" +
                    "false;;360011033;Red Nova;Eastern Asia;;Eastern Asia;;2022-02-18 03:25;;;Dirty;Crude/Co;;;-339250.0;-2133818;-280220;;false;false;false;9602643;636019391;344416;;VLCC;90869;;289;;Eastern Asia;Asia;;;34312332;;;VLCC\n"),
                HasHeaders = true,
                Delimiter = ";"
            };

            var result = sut.Deserialize<PortCall>(args);
        }


        [Fact]
        public void Can_Deserialize_InTransit()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("2021-01-19|913939.0|kbbl\n2021 - 01 - 26 | 926178.0 | kbbl\n2021 - 02 - 02 | 910887.0 | kbbl\n2021 - 02 - 09 | 914570.0 | kbbl\n2021 - 02 - 16 | 903967.0 | kbbl\n"),
                Delimiter = "|",
                HasHeaders = false,
            };

            var result = objectifier.Deserialize<FakeInTransit>(args);

            var test = result.First();

            Assert.Equal(913939, test.OilInTransit);
        }

        [Fact]
        public void Can_Deserialize_TT_EEX()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("Date,Time,Message Type,TT Order ID,TT Instrument ID,Product Type,Product Symbol,Maturity Date,TT Request ID,Exchange Request ID,Exchange Order ID,Exchange Link Association,Order Type,Time In Force,Expire Date,Execution Type,Order Status,Text,Reject Source,Side,Order Qty,Cum Qty,Leaves Qty,Min Qty,Last Qty,Display Qty,Refresh Qty,Exchange Order Qty,Exchange Leaves Qty,Exchange Cum Qty,Price,Last Price,Stop Price,Execution ID,Trade Date,Account,Sender Sub ID,TT Connection ID,Security Request ID,Security Definition Status,TT User ID,TT Account ID,User ID,Take Up Member,Exchange Account,Text 1,Text 3,Account Code,ComplianceID,Quote Request ID,Quote Status,Headline,TT Current User ID,IP Address,DirectElectronicAccess,TradingCapacity,LiquidityProvision,CommodityDerivIndicator,InvestmentDecision,InvestmentDecisionIsAlgo,ExecutionDecision,ExecutionDecisionIsAlgo,ClientIDCode,CustomerDefinedClientIDCode,TV TIC,TT FIX Client Order ID,TT FIX Original Client Order ID,TT Execution ID,Exchange Latency,Prompt Date\n" + 
                "Jun22, 10:28:36.391649963,NewOrderSingle,f3debca5 - 7740 - 4467 - 964f - a85805c01afd,8808206051423250592,FUT,G3BY,2022-12-08,21,1655869200174,,90213233,ORD_TYPE_LIMIT,TIME_IN_FORCE_DAY,,EXEC_TYPE_PENDING_NEW,ORD_STATUS_PENDING_NEW,,,B,2,0,2,,,,,2,0,0,91.0,,,HXWC33DVcha3V9uwU7QpZB,,G1127404,62541,1066488, , ,1125128,1194592,62541,,G1127404,,,A1,, , , , ,,Y,A,0,0,,,,N,2040,, ,,, , ,"),
                Delimiter = ",",
                HasHeaders = true,
                ClassMap = new EexAuditClassMap()
            };

            var result = objectifier.Deserialize<EexAudit>(args);

            var test = result.First();

            Assert.Equal("8808206051423250592", test.TTInstrumentID);
        }

        [Fact]
        public void Can_Deserialize_TT_CME()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("Sending Timestamps,Receiving Timestamps,Message Direction,Operator ID,Self-Match Prevention ID,Account Number,Session ID,Executing Firm ID,Manual Order Identifier,Message Type,Customer Type Indicator,Origin,CME Globex Message ID,Message Link ID,Order Flow ID,Spread/Leg Link ID,Instrument Description,Market Segment ID,Client Order ID,CME Globex Order ID,Buy/Sell Indicator,Quantity,Limit Price,Stop Price,Order Type,Order Qualifier,IFM Flag,Display Quantity,Minimum Quantity,Country of Origin,Fill Price,Fill Quantity,Cumulative Quantity,Remaining Quantity,Aggressor Flag,Source of Cancellation,Reject Reason,Processed Quotes,Cross ID,Quote Request ID,Message Quote ID,Quote Entry ID,Bid Price,Bid Size,Offer Price,Offer Size,Product/Instrument Group Code,Exchange Code,TT User ID,TT Current User ID,TT FIX Client Order ID,TT FIX Original Client Order ID,TT Order ID,TT Account ID,TT Instrument ID\n, 20220630 - 18:28:17.073,FROM CME, LGOH,, G1127406, GGT,0OS,Y,8\\1,4,0,78673:M: 1627232TN0000006,d44a4696 - ea6e - 468a - b351 - 9d6bb3c17c60,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,\"786963830401202206306\",NGJ5,78,1656281896453,786963830401,1,5,4000.0,,2,1, ,,,\"GB\",4000.0,1,1,4,N,,, ,, , , , , , , ,892,XNYM,1125128,1125128,,,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,1194593,12362180193617520569\n20220630 - 18:28:17.073,,TO CLIENT, LGOH,, G1127406, GGT,0OS,Y,8\\1,4,0,78673:M: 1627232TN0000006,d44a4696 - ea6e - 468a - b351 - 9d6bb3c17c60,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,\"786963830401202206306\",NGJ5,78,1656281896453,786963830401,1,5,4000.0,,2,1, ,,,\"GB\",4000.0,1,1,4,N,,, ,, , , , , , , ,892,XNYM,1125128,1125128,,,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,1194593,12362180193617520569\n,20220630 - 18:28:21.538,FROM CME, LGOH,, G1127406, GGT,0OS,Y,8\\1,4,0,78673:M: 1628913TN0000008,91be965c - e657 - 4909 - ba72 - 120d2cd65465,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,\"786963830401202206308\",NGJ5,78,1656281896453,786963830401,1,5,4000.0,,2,1, ,,,\"GB\",4000.0,1,2,3,N,,, ,, , , , , , , ,892,XNYM,1125128,1125128,,,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,1194593,12362180193617520569\n20220630 - 18:28:21.538,,TO CLIENT, LGOH,, G1127406, GGT,0OS,Y,8\\1,4,0,78673:M: 1628913TN0000008,91be965c - e657 - 4909 - ba72 - 120d2cd65465,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,\"786963830401202206308\",NGJ5,78,1656281896453,786963830401,1,5,4000.0,,2,1, ,,,\"GB\",4000.0,1,2,3,N,,, ,, , , , , , , ,892,XNYM,1125128,1125128,,,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,1194593,12362180193617520569\n,20220630 - 18:28:21.903,FROM CME, LGOH,, G1127406, GGT,0OS,Y,8\\1,4,0,78673:M: 1629138TN0000009,d9e3edf7 - b7e1 - 4170 - ab77 - f26d872e6ba3,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,\"786963830401202206309\",NGJ5,78,1656281896453,786963830401,1,5,4000.0,,2,1, ,,,\"GB\",4000.0,2,4,1,N,,, ,, , , , , , , ,892,XNYM,1125128,1125128,,,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,1194593,12362180193617520569\n20220630 - 18:28:21.904,,TO CLIENT, LGOH,, G1127406, GGT,0OS,Y,8\\1,4,0,78673:M: 1629138TN0000009,d9e3edf7 - b7e1 - 4170 - ab77 - f26d872e6ba3,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,\"786963830401202206309\",NGJ5,78,1656281896453,786963830401,1,5,4000.0,,2,1, ,,,\"GB\",4000.0,2,4,1,N,,, ,, , , , , , , ,892,XNYM,1125128,1125128,,,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,1194593,12362180193617520569,20220630 - 18:28:21.905,FROM CME, LGOH,, G1127406, GGT,0OS,Y,8\\2,4,0,78673:M: 1629200TN0000010,e63ab008 - 16ef - 4ec2 - 98f1 - 2f245fb28866,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,\"7869638304012022063010\",NGJ5,78,1656281896453,786963830401,1,5,4000.0,,2,1, ,,,\"GB\",4000.0,1,5,0,N,,, ,, , , , , , , ,892,XNYM,1125128,1125128,,,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,1194593,12362180193617520569\n20220630 - 18:28:21.905,,TO CLIENT, LGOH,, G1127406, GGT,0OS,Y,8\\2,4,0,78673:M: 1629200TN0000010,e63ab008 - 16ef - 4ec2 - 98f1 - 2f245fb28866,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,\"7869638304012022063010\",NGJ5,78,1656281896453,786963830401,1,5,4000.0,,2,1, ,,,\"GB\",4000.0,1,5,0,N,,, ,, , , , , , , ,892,XNYM,1125128,1125128,,,d5590186 - 3dfd - 46f1 - bb0a - f2d82a7051f6,1194593,12362180193617520569"),
                Delimiter = ",",
                HasHeaders = true,
                //ClassMap = new CmeAuditClassMap()
            };

            var result = objectifier.Deserialize<CmeAudit>(args);

            var test = result.First();

            Assert.Equal(true, true);
        }


        [Fact]
        public void Can_Deserialize_OilAndGas()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("Id|API Average|API Category|API Group|Oil and Gas Category\n220|NGL|Non-Crude Liquids|Non-Crude Liquids|NGL\n221 | Ethane | Non - Crude Liquids | Non - Crude Liquids | NGL\n222 | Propane | Non - Crude Liquids | Non - Crude Liquids | NGL\n"),
                Delimiter = "|",
                HasHeaders = true,
            };

            var result = objectifier.Deserialize<FakeOilAndGas>(args);

            var test = result.First();

            Assert.Null(test.ApiAverage);
        }


        [Fact]
        public void Can_Deserialize_PVM_Marks()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("20220701|954.0|EFS|20220517\n"),
                Delimiter = "|",
                HasHeaders = false,
            };

            var result = objectifier.Deserialize<Mark>(args);

            var test = result.First();

            Assert.True(test.Quote == 954.0);
        }

        [Fact]
        public void Can_Deserialize_PVM_MarkToMarketCfds()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("Week1|13-17/6|20220901|802.0|CFD|20220609\n"),
                Delimiter = "|",
                HasHeaders = false,
            };

            var result = objectifier.Deserialize<MarkToMarketCFD>(args);

            var test = result.First();

            Assert.True(test.WeekNumber == 1);
        }

        [Fact]
        public void Can_Deserialize_ICE_Downloads()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("TRADE DATE|HUB|PRODUCT|STRIP|CONTRACT|CONTRACT TYPE|STRIKE|SETTLEMENT PRICE|NET CHANGE|EXPIRATION DATE|PRODUCT_ID\n6/8/2022|REC-CT CI|REC-CT Futures|Apr23 V22|CTT|F||37.70000|-1.29000|4/25/2023|20109\n"),
                Delimiter = "|",
                HasHeaders = true,
            };

            var result = objectifier.Deserialize<IceCleared>(args);

            var test = result.First();

            Assert.True(test.Strip == new System.DateTime(2023, 4, 1));
        }

        [Fact]
        public void Can_Deserialize_Price_Upload()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("Asof,Source,Contract Code,Name,External Id,Price Type,Price Time,Instrument,Value,Contract Date,Expiry Date,Strike,Delta,Implied Vol,Open Interest,Volume\n" + 
                "19/07/2022,ICE,B,North Sea,254,Settlement,COB,Future,101.56,01/08/2022,,,,,600,2000"),
                Delimiter = ",",
                HasHeaders = true,
            };

            var result = objectifier.Deserialize<GenericQuote>(args);

            var test = result.First();

            Assert.True(test.Name == "North Sea");
        }

        [Fact]
        public void Can_Deserialize_ECBRates()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("KEY,FREQ,CURRENCY,CURRENCY_DENOM,EXR_TYPE,EXR_SUFFIX,TIME_PERIOD,OBS_VALUE," +
                    "OBS_STATUS,OBS_CONF,OBS_PRE_BREAK,OBS_COM,TIME_FORMAT,BREAKS,COLLECTION,COMPILING_ORG,DISS_ORG,DOM_SER_IDS" +
                    ",PUBL_ECB,PUBL_MU,PUBL_PUBLIC,UNIT_INDEX_BASE,COMPILATION,COVERAGE,DECIMALS,NAT_TITLE,SOURCE_AGENCY,SOURCE_PUB" +
                    ",TITLE,TITLE_COMPL,UNIT,UNIT_MULT\n" +
                    "EXR.D.GBP.EUR.SP00.A,D,GBP,EUR,SP00,A,1999-12-31,,H,,,,P1D,,A,,,,,,,,,,5,,4F0,,UK pound sterling/Euro,\"ECB reference exchange rate, UK pound sterling / Euro, 2:15 pm(C.E.T.)\",GBP,0\n"),
                Delimiter = ",",
                HasHeaders = true,
            };

            var result = objectifier.Deserialize<Rate>(args);

            var test = result.First();

            Assert.True(test.Value == null);
        }

        [Fact]
        public void Can_Deserialize_Rystad_Timeline()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("Id|Month|Quarter|Year Month|Year|Days|QuarterYear|MonthSeriesNumber|QuarterSeriesNumber\r\n"+ 
                    "2010101|1|1|2010-01|2010|31|2010 Q1|1|1"),
                Delimiter = "|",
                HasHeaders = true,
                AcceptedDateFormats = new List<string> { "yyyy-MM" }
            };

            var result = objectifier.Deserialize<FakeTimeline>(args);

            var test = result.First();

            Assert.True(test.Month == 1);
        }

        [Fact]
        public void Can_Deserialize_Eex_Option()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("# Prices/Volumes of EEX German Power (Futures-Style) Options\r\n" +
                    "#\r\n" +
                    "# Data type(ST);Trading Date;Creation Time\r\n" +
                    "# Data type(PR);Product;Long Name;Underlying;Maturity;Delivery Start;Delivery End;Type;Strike;Open Price;Timestamp Open Price;High Price;Timestamp High Price;Low Price;Timestamp Low Price;Last Price;Timestamp Last Price;Settlement Price;Unit of Prices;Lot Size;Traded Lots;Number of Trades;Traded Volume;Open Interest Lots;Open Interest Volume;Unit of Volumes\r\n" +
                    "# Data type(OT);Product;Long Name;Underlying;Maturity;Delivery Start;Delivery End;Type;Strike;Lot Size;Traded Lots;Number of Trades;Traded Volume;Unit of Volumes\r\n" +
                    "# Data type(AL);Number of Lines\r\n" +
                    "#\r\n" +
                    "ST;2022-09-19;2022-09-19T19:29:19Z\r\n" +
                    "PR;O2FM;EEX German Base Month Option (Future Style);DEBM;2022-10;2022-10-01;2022-10-31;C;300;;;;;;;;;61.336;EUR/MWh;745;;;;;;MWh\r\n" +
                    "OT;O2FQ;EEX German Base Quarter Option (Future Style);DEBQ;2022-10;2022-10-01;2022-12-31;C;561;2209;;;;\r\n"),
                Delimiter = ";",
                HasHeaders = false,
                SkipRowsBeginningWith = new List<string> { "#", "ST", "OT" }
            };

            var result = objectifier.Deserialize<FakeEexOption>(args);

            var test = result.Single();

            Assert.True(test.LongName == "EEX German Base Month Option (Future Style)");
        }
        [Fact]
        public void Can_Deserialize_PetLog_Movements()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("Result: ,success,Rows Returned: ,414,Error Message,none\n" +
                    "Yuriy Kuchiev,9804033,52292,Cy,Canitis,2022-09-14,,Sabetta,Russia,Baltic Sea,Former Soviet Union,50000,422500,8.45000,Condensate,,0,,2022-09-27,Rotterdam,,,Netherlands,Europe,,,,0,,,,,W37,2022,M09,Q3,2022,W39,2022,M09,Q3,2022,0.00,2620779694,0\n"),
                Delimiter = ",",
                HasHeaders = false,
                SkipRowsBeginningWith = new List<string> { "Result" }
            };

            var result = objectifier.Deserialize<Movement>(args);

            var test = result.Single();

            Assert.True(test.TankerName == "Yuriy Kuchiev");
        }

        [Fact]
        public void Can_Raise_CsvHelper_Errors()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("2022-00\n"),
                Delimiter = ",",
                HasHeaders = false
            };

            var result = objectifier.Deserialize<Dummy>(args);

            Assert.Single(objectifier.Exceptions.Where(e => e.Message.Contains("An unexpected error occurred")));
        }
    }
}
