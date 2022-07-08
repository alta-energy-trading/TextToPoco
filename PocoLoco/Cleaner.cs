using System;
using System.Collections.Generic;
using System.Reflection;
using TextToPoco.Core;

namespace PocoLoco
{
    public class Cleaner : IPocoLocoCleaner
    {
        private readonly ICleaner _cleaner;

        public Cleaner(ICleaner cleaner)
        {
            _cleaner =  cleaner;
        }

        public IEnumerable<TTarget> Clean<TSource, TTarget>(IDbContext context, IEnumerable<TSource> entities, 
            IClientCleaner clientCleaner, PersistActionEnum persistAction = PersistActionEnum.Merge)
            where TSource : class
            where TTarget : class
        {
            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);

            var cleanMethod = typeof(ICleaner)
                .GetMethod("Clean", BindingFlags.Public | BindingFlags.Instance)
                .MakeGenericMethod(new Type[] { sourceType, targetType });

            return (IEnumerable<TTarget>)cleanMethod
                .Invoke(_cleaner, new object[] { context, entities, clientCleaner, persistAction});
        }
    }
}
