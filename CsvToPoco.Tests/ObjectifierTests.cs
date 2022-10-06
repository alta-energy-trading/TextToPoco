using CsvToPoco.Tests.Fakes;
using CsvToPoco.Tests.Fakes.ClassMaps;
using System.Linq;
using Xunit;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Reflection;
using System.Security.Cryptography;

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
                "Jun22, 10:28:36.391649963,NewOrderSingle,f3debca5 - 7740 - 4467 - 964f - a85805c01afd,8808206051423250592,FUT,G3BY,2022-12-01,21,1655869200174,,90213233,ORD_TYPE_LIMIT,TIME_IN_FORCE_DAY,,EXEC_TYPE_PENDING_NEW,ORD_STATUS_PENDING_NEW,,,B,2,0,2,,,,,2,0,0,91.0,,,HXWC33DVcha3V9uwU7QpZB,,G1127404,62541,1066488, , ,1125128,1194592,62541,,G1127404,,,A1,, , , , ,,Y,A,0,0,,,,N,2040,, ,,, , ,"),
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
                ClassMap = new CmeAuditClassMap()
            };

            var result = objectifier.Deserialize<CmeAudit>(args);

            var test = result.First();

            Assert.Equal(true, true);
        }


        [Fact]
        public void Can_Deserialize_TT_RawFills()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("Time,Date,Account,Contract,Product,Originator,CurrentUser,Price,PriceInTicks,TrigPrc,TrigPrcInTicks,FillQty,WorkQty,ExeQty,ExchOrderID,ExchTransID,ClOrderID,TTOrderID,ParentID,Fill Type,Strike,D.E.A.,ExchDate,P/F,ConnectionID,Type,P/C,P/A,ExchTime,O/C,ExchAcct,Route,ManualFill,TrdgCap,OMAOrderID,Confirmed,Exchange,B/S,Prod Type,Broker,InvestDec,ExecDec,LiqProv,C.D.I,GiveUp,Client,Modifier,TextA,TextB,TextTT,TimeSent,DealDate,DealTime,CounterParty,AlgoName,Trd Mbr,Trd Grp,Exch Trd,AcctType,OriginalDate,OriginalTime,SharedAccountName,Term,SecondaryClient,SecondaryExecutionDecisionMaker,ComplianceText,InvestDecQ,ExecDecQ,MaturityDate,Expiry,InstrumentID,ClearingDate,OrderProfile\n" +
                " 15:35:38.526, 2022-10-05, G1127410, RP Dec22, RP, MAndersson, MAndersson, 0.87910000, 17582.0,,, 2.0, 4.0, 2.0, 5221391032311, 52687:M:1361063TN0001088, 1664733639582, 58219d52-d0e4-4162-ada5-13f90667c762,, SINGLE_SECURITY,, N, 2022-10-05, PARTIALLY_FILLED, 1429, LIMIT,, A, 15:35:38.526, CLOSE, G1127410, Direct,, Other,, False, CME, BUY, FUTURE, Macquarie Group,,,,,,, Iceberg,,,, 1664984138526808727,,,,,,,,, 2022-10-05, 15:35:38.486,, Dec22,,,,,, 12/19/2022, RP Dec22, 10649380637663073361, 2022-10-05,"),
                Delimiter = ",",
                HasHeaders = true,
                AcceptedDateFormats = new List<string> { "yyyy-MM-dd", " yyyy-MM-dd", "MM/dd/yyyy", " MM/dd/yyyy" },
                ClassMap = new RawFillClassMap()
            };

            var result = objectifier.Deserialize<RawFill>(args);

            var test = result.First();

            Assert.Equal(" FUTURE", test.ProdType);
            Assert.Equal(" 5221391032311", test.ExchOrderID);
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
            //TODO: Week1?
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
                Stream = FakeStream.FromString("TRADE DATE|HUB|PRODUCT|STRIP|CONTRACT|CONTRACT TYPE|STRIKE|SETTLEMENT PRICE|NET CHANGE|EXPIRATION DATE|PRODUCT_ID\n6/8/2022|REC-CT CI|REC-CT Futures|4/25/2023|CTT|F||37.70000|-1.29000|4/25/2023|20109\n"),
                Delimiter = "|",
                HasHeaders = true,
                AcceptedDateFormats = new List<string> {
                    "MM/dd/yyyy",
                    "M/d/yyyy",
                }
            };

            var result = objectifier.Deserialize<IceCleared>(args);

            var test = result.First();

            Assert.True(test.Strip == new System.DateTime(2023, 4, 25));
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

        [Fact]
        public void Can_Deserialize_Kpler_Trades()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("Vessel;Country (origin);Zone Origin;Installation origin;End (origin);Country (destination);Zone Destination;Installation Destination;Start (destination);Volume (bbl);Family;Group;Product;Grade;Id (Trade);Origin PortCall Id;Destination PortCall Id;Id (Voyage);Zone Origin Id;Zone Destination Id;Installation origin id;Installation Destination Id;Continent Destination;Continent Origin;Mileage;Ton Miles;Import price;Number of trades (import);Export price;Number of trades (export);Date (origin);Origin;Reload STS Partial (origin);Date (destination);Destination;Reload STS Partial (destination);Forecasted destination;Forecasted ETA;Forecasted confidence;Forecasted origin;Forecasted origin ETA;Forecasted origin confidence;Trade status;Seller (origin);Buyer (destination);Intermediaries;Subcontinent (origin);Eta (origin);Start (origin);Eta source (origin);Eta source (destination);Subcontinent (destination);Eta (destination);End (destination);Capacity (vessel m3);Vessel type;Cargo type (vessel);Id (vessel);IMO (vessel);MMSI (vessel);Charterer;Zone Canal Transit;Link1 delivery;Link1 type;Link1 seller name;Link1 seller country;Link1 buyer name;Link1 buyer country;Link2 delivery;Link2 type;Link2 seller name;Link2 seller country;Link2 buyer name;Link2 buyer country;Link3 delivery;Link3 type;Link3 seller name;Link3 seller country;Link3 buyer name;Link3 buyer country;Link4 delivery;Link4 type;Link4 seller name;Link4 seller country;Link4 buyer name;Link4 buyer country;Link5 delivery;Link5 type;Link5 seller name;Link5 seller country;Link5 buyer name;Link5 buyer country;Cargo (tons);Vessel Id 2;Vessel Id 3;Voyage Id 2;Voyage Id 3;Vessel Name 2;Vessel Name 3;Vessel IMO 2;Vessel IMO 3;Zone STS 1;Zone STS 2;Zone STS Id 1;Zone STS Id 2;Date Start STS 1;Date Start STS 2;Date End STS 1;Date End STS 2;Grade API;Grade Sulfur;Country STS 1;Country STS 2;Vessel DWT;Vessel DWT 2;Vessel DWT 3;Installation STS 1;Installation STS 2;Volume STS 1;Volume STS 2;Cargo Sources;Id (Product);Voyage Id 4;Vessel Id 4;Vessel Name 4;Vessel IMO 4;Vessel DWT 4;Zone STS 3;Zone STS Id 3;Date Start STS 3;Date End STS 3;Country STS 3;Installation STS 3;Volume STS 3;Estimated Product - Confidence;Estimated products;Estimated Products - Confidences;Vessel Type 2;Vessel Type 3;Vessel Type Alternative ;Vessel Type Alternative 2;Vessel Type Alternative 3;Vessel Type 4;Vessel Type Alternative 4;Id (Shipment);Parent Id (Shipment);TradingRegion (origin);TradingRegion (destination);Vessel Owner;Vessel Owner 2;Vessel Owner 3;Vessel Owner 4;Kpler Date (destination);Kpler Date (origin)\n" + 
                    "Olympic Light;Saudi Arabia;Ras Tanura;;;South Korea;Ulsan;;;2116106;Dirty;Crude / Co;Crude;Arab;15372923;;;36615346;2412;2527;;;Asia;Asia;;;;;;;2022-11-23 16:37;Ras Tanura;;2022-12-29 16:37;Ulsan;;Ulsan;2022-12-29 16:37;0.99;Ras Tanura;2022-11-22 08:44;0.54;Scheduled;Aramco;KNOC,S - Oil,SK;1;Middle East;2022-11-22 08:44;;Model;Model;Eastern Asia;2022-12-29 16:37;;341557;VLCC;;81397;9424273;241330000;;;FOB;Spot;Aramco;Saudi Arabia;;;DES;Spot;;;KNOC,S - Oil,SK;;;;;;;;;;;;;;;;;;;;277894;;;;;;;;;;;;;;;;;33.35;2.11;;;317106;;;;;;;Algorithm;1092;;;;;;;;;;;;;;;;;;VLCC;;;;;6792395;;Mideast Gulf;Eastern Asia;Olympic Shipping;;;;;\n"),
                Delimiter = ";",
                HasHeaders = true,
                AcceptedDateFormats = new List<string> {
                    "dd/MM/yyyy",
                    "yyyy-MM-dd HH:mm",
                    "MMMyy",
                    "yyyy/MM/dd",
                    "yyyy-MM-dd",
                    "yyyy-MM",
                    "HH:mm:ss.fffff"
                }
            };
            var result = objectifier.Deserialize<Trade>(args);
            var test = result.Single();
            Assert.True(test.Vessel == "Olympic Light");
        }

        [Fact]
        public void Can_Deserialize_Kpler_PortCalls()
        {
            Objectifier objectifier = new Objectifier();
            ITextToPocoArgs args = new CsvToPocoArgs
            {
                Stream = FakeStream.FromString("Forecasted;Confidence;Id (portCall);Vessel;Location;Installation;zone;Country;ETA;Start;End;Family;Group;Product;Grade;Volume (m3);Volume (bbl);Cargo (tons);Charterer;Reexport;PartialCargo;Ship to ship;IMO (vessel);MMSI (vessel);Capacity (m3);Cargo type (vessel);Vessel type;Id (vessel);Id (installation);Id (zone);Type (installation);SubContinent;Continent;Storage capacity (installation);Status (installation);Id (voyage);Grade API;Grade Sulfur;Vessel Type Alternative\n" +
                    "false;;366084634;Bouboulina;Ceyhan;;Ceyhan;Turkey;2023-01-01 19:00;;;Dirty;Crude/Co;Crude;;171353.0;1077777;141537;;false;false;false;9298753;240463000;173962;;Suezmax;74174;;2457;;Eastern Europe;Europe;;;36608788;;;\n" +
                    "true;;366017613;La Lobe;Ebome;Ebome;Ebome;Cameroon;2023-01-01 00:00;;;Dirty;Crude/Co;Crude;Ebome;74753.0;470182;64661;;false;false;false;7924932;256563000;75891;;Panamax;110707;1581;1267;Crude Oil Production;Western Africa;Africa;;Active;36582562;32.1;0.35;\n"),
                Delimiter = ";",
                HasHeaders = true,
                AcceptedDateFormats = new List<string> {
                    "dd/MM/yyyy",
                    "yyyy-MM-dd HH:mm",
                    "MMMyy",
                    "yyyy/MM/dd",
                    "yyyy-MM-dd",
                    "yyyy-MM",
                    "HH:mm:ss.fffff"
                }
            };
            var result = objectifier.Deserialize<PortCall>(args, 1).ToList();
            
            Assert.Collection(result,
                i => Assert.Collection(i,
                    j => Assert.False(j.Forecasted)),
                i => Assert.Collection(i,
                    j => Assert.True(j.Forecasted)));
        }
    }
}
