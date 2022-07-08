using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TextToPoco.Core;
using TextToPoco.Data.Extensions;

[assembly: InternalsVisibleTo("JsonToPoco.Tests")]
[assembly: InternalsVisibleTo("CsvToPoco.Tests")]
namespace TextToPoco.Services
{
    public class TextImporter : IImporter
    {
        private readonly IObjectifier _objectifier;

        public TextImporter(IObjectifier objectifier)
        {
            _objectifier = objectifier;
            Exceptions = new List<Exception>();
        }

        public List<Exception> Exceptions { get; set; }

        public void RaiseWarnings(List<Exception> warnings)
        {
            Exceptions = warnings;
        }

        public IEnumerable<IEnumerable<T>> Import<T>(IDbContext context, ITextToPocoArgs args, int batchSize) where T : class, new()
        {
            foreach (var batch in _objectifier.Deserialize<T>(args, batchSize))
            {
                List<T> newList = batch.ToList();

                switch (args.PersistAction)
                {
                    case PersistActionEnum.Merge:
                        context.Merge(newList, args.Keys, args.PropertiesToInclude);
                        break;
                    case PersistActionEnum.Replace:
                        context.Merge(newList, args.Keys, args.PropertiesToInclude); // Can't replace with batches, because each batch would truncate the previous
                        break;
                    case PersistActionEnum.None:
                        break;
                    case PersistActionEnum.Add:
                        context.Add(newList);
                        break;
                    default:
                        throw new NotImplementedException("TextImporter");
                }
                yield return batch;

            };

            RaiseWarnings(_objectifier.Exceptions);
        }

        public IEnumerable<T> Import<T>(IDbContext context, ITextToPocoArgs args) where T : class, new()
        {
            var records = _objectifier.Deserialize<T>(args);

            RaiseWarnings(_objectifier.Exceptions);

            switch (args.PersistAction)
            {
                case PersistActionEnum.Merge:
                    return context.Merge(records, args.Keys, args.PropertiesToInclude);
                case PersistActionEnum.Replace:
                    return context.Replace(records);
                case PersistActionEnum.None:
                    return records;
                case PersistActionEnum.Add:
                    context.Add(records);
                    return records;
                default:
                    throw new NotImplementedException("TextImporter");
            }
        }
    }
}
