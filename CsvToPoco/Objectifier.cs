using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Runtime.CompilerServices;
using TextToPoco.Core;
using System.Linq;
using CsvToPoco.CustomTypeConverters;

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
                csv.Context.RegisterClassMap(csvArgs.ClassMap);
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
                csv.Context.RegisterClassMap(csvArgs.ClassMap);
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
