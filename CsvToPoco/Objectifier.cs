﻿using System;
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
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = csvArgs.HasHeaders,                
                Delimiter = csvArgs.Delimiter,
                ReadingExceptionOccurred = args => ReadingExceptionOccurred(args)
                
            };

            using(StreamReader reader = new StreamReader(args.Stream))
            using (var csv = new CsvReader(reader, config))
            {
                ConfigureContext(csvArgs, csv);

                tempList.AddRange(csv.GetRecords<T>());
                return tempList;
            }
        }

        public IEnumerable<IEnumerable<T>> Deserialize<T>(ITextToPocoArgs args, int batchSize) where T : class, new()
        {
            var csvArgs = (CsvToPocoArgs)args;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = csvArgs.HasHeaders,
                Delimiter = csvArgs.Delimiter,
                ReadingExceptionOccurred = args => ReadingExceptionOccurred(args)
            };
            
            using (StreamReader reader = new StreamReader(args.Stream))
            using (var csv = new CsvReader(reader, config))
            {
                ConfigureContext(csvArgs, csv);

                List<T> result = new List<T>();
                foreach (var record in csv.GetRecords<T>())
                {
                    result.Add(record);
                    if (result.Count == batchSize)
                    {
                        yield return result.ToList();
                        result.Clear();
                    }
                }
                yield return result.ToList(); // return remaining records
            }
        }

        private static void ConfigureContext(CsvToPocoArgs csvArgs, CsvReader csv)
        {
            if (csvArgs.ClassMap != null)
                csv.Context.RegisterClassMap(csvArgs.ClassMap);
            var options = new TypeConverterOptions
            {
                Formats = new[] {
                    "dd/MM/yyyy",
                    "MM/dd/yyyy",
                    "M/d/yyyy",
                    "MMMyy",
                    "yyyy/MM/dd",
                    "yyyy-MM-dd",
                    "HH:mm:ss.fffff"
                }
            };
            csv.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);
            csv.Context.TypeConverterOptionsCache.AddOptions<DateTime?>(options);
        }

        public bool ReadingExceptionOccurred(ReadingExceptionOccurredArgs args)
        {
            if (args.Exception.InnerException != null)
            {
                if (!Exceptions.Contains(args.Exception.InnerException))
                    Exceptions.Add(args.Exception.InnerException);
            }
            else if (!Exceptions.Contains(args.Exception))
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
