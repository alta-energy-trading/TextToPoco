using System;
using System.Collections.Generic;
using CsvHelper;
using System.Runtime.CompilerServices;
using System.Text.Json;
using TextToPoco.Core;
using System.IO;

[assembly: InternalsVisibleTo("JsonToPoco.Tests")]
namespace JsonToPoco
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
            var jsonArgs = args as JsonToPocoArgs;
            var result = JsonSerializer.DeserializeAsync(args.Stream, jsonArgs.RootType).Result;
            return (IEnumerable<T>)result.GetType().GetProperty(jsonArgs.CollectionName).GetValue(result);
        }

        public IEnumerable<IEnumerable<T>> Deserialize<T>(ITextToPocoArgs args, int batchSize) where T : class, new()
        {
            throw new NotImplementedException();
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

        public IEnumerable<IEnumerable<T>> BatchDeserialize<T>(ITextToPocoArgs args) where T : class, new()
        {
            throw new NotImplementedException();
        }
    }
}
