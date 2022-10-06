using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Runtime.CompilerServices;
using System.Linq;
using CsvToPoco.CustomTypeConverters;
using CsvHelper.TypeConversion;

[assembly: InternalsVisibleTo("CsvToPoco.Tests")]
namespace CsvToPoco
{
    
    internal class Objectifier : IObjectifier
    {
        public List<Exception> Exceptions { get; set; }

        public Objectifier()
        {
            Exceptions = new List<Exception>();
        }

        public IEnumerable<T> Deserialize<T>(ITextToPocoArgs args)
            where T : class, new()
        {
            List<T> tempList = new List<T>();

            var csvArgs = (CsvToPocoArgs)args;
            CsvConfiguration config = BuildConfig(csvArgs);

            using (StreamReader reader = new StreamReader(args.Stream))
            using (var csv = new CsvReader(reader, config))
            {
                ConfigureContext(csvArgs, csv);

                tempList.AddRange(csv.GetRecords<T>());
                return tempList;
            }
        }

        private CsvConfiguration BuildConfig(CsvToPocoArgs csvArgs)
        {
            return new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = csvArgs.HasHeaders,
                Delimiter = csvArgs.Delimiter,
                ReadingExceptionOccurred = args => ReadingExceptionOccurred(args),
                ShouldSkipRecord = args => csvArgs.SkipRowsBeginningWith.Any(s => args.Record[0].StartsWith(s))
            };
        }

        public IEnumerable<IEnumerable<T>> Deserialize<T>(ITextToPocoArgs args, int batchSize) where T : class, new()
        {
            var csvArgs = (CsvToPocoArgs)args;

            CsvConfiguration config = BuildConfig(csvArgs);

            using (StreamReader reader = new StreamReader(args.Stream))
            using (var csv = new CsvReader(reader, config))
            {
                ConfigureContext(csvArgs, csv);

                List<T> result = new List<T>();
                foreach (var record in csv.GetRecords<T>())
                {
                    if(record != null)
                        result.Add(record);
                    if (result.Count == batchSize)
                    {
                        yield return result.ToList();
                        result.Clear();
                    }
                }
                if(result.Any())
                    yield return result.ToList(); // return remaining records
            }
        }

        private static void ConfigureContext(CsvToPocoArgs csvArgs, CsvReader csv)
        {
            if (csvArgs.ClassMap != null)
                csv.Context.RegisterClassMap(csvArgs.ClassMap);

            var formats = csvArgs.AcceptedDateFormats == null ?
                new List<string> {
                    "dd/MM/yyyy",
                    //"MM/dd/yyyy",
                    //"M/d/yyyy",
                    "MMMyy",
                    "yyyy/MM/dd",
                    "yyyy-MM-dd",
                    "yyyy-MM",
                    "HH:mm:ss.fffff"
                } :
                csvArgs.AcceptedDateFormats;

            var options = new TypeConverterOptions
            {
                Formats = formats.ToArray()
            };
            csv.Context.Configuration.Mode = CsvMode.NoEscape;
            csv.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);
            csv.Context.TypeConverterOptionsCache.AddOptions<DateTime?>(options);
        }

        public bool ReadingExceptionOccurred(ReadingExceptionOccurredArgs args)
        {
            if (!Exceptions.Any(e => e.Message == args.Exception.Message))
                Exceptions.Add(args.Exception);

            return false;
        }

        public IEnumerable<IEnumerable<T>> BatchDeserialize<T>(CsvToPocoArgs args) where T : class, new()
        {
            List<T> tempList = new List<T>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = args.HasHeaders,
                Delimiter = args.Delimiter,
                ReadingExceptionOccurred = args => ReadingExceptionOccurred(args)
            };

            using (StreamReader reader = new StreamReader(args.Stream))
            using (var csv = new CsvReader(reader, config))
            {
                tempList.AddRange(csv.GetRecords<T>());

                if (tempList.Count > 100000)
                {
                    yield return tempList.Select(e => e);
                    tempList.Clear();
                }
            }
        }
    }
}
