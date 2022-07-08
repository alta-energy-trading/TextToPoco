using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Runtime.CompilerServices;
using TextToPoco.Core;
using TextToPoco.Data.Extensions;

[assembly: InternalsVisibleTo("PocoLoco.Tests")]
namespace PocoLoco
{
    internal class CleanerService : ICleaner
    {
        public IEnumerable<TTarget> Clean<TSource, TTarget>(IDbContext context, IEnumerable<TSource> entities, IClientCleaner cleaner, PersistActionEnum persistAction = PersistActionEnum.Merge)
            where TSource : class
            where TTarget : class
        {
            var clean = entities
                .Select(async e => await cleaner.Clean<TSource, TTarget>(e))
                .Select(t => t.Result)
                .Where(r => r != null)
                .SelectMany(l => l
                    .Where(e => e != null))
                .Where(e => e != null)
                .AsQueryable();

            IEnumerable<TTarget> result;

            if (cleaner.Keys != null && cleaner.Keys.Any())
                result = clean
                    .GroupBy($"new({String.Join(",", cleaner.Keys)})")
                    .Cast<IGrouping<object, TTarget>>()
                    .SelectMany(g => g.Take(1).Select(e => e));
            else
                result = clean;

            switch (persistAction)
            {
                case PersistActionEnum.Merge:
                    return context.Merge(result, cleaner.Keys, cleaner.PropertiesToInclude);
                case PersistActionEnum.Replace:
                    return context.Replace(result);
                default:
                    return result;
            }
        }
    }
}
