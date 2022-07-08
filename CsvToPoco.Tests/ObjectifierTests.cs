using CsvToPoco.Tests.Fakes;
using System.IO;
using System.Linq;
using TextToPoco.Core;
using Xunit;

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
    }
}
