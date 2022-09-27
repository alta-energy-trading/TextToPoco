using System;
using System.Collections.Generic;

namespace CsvToPoco
{
    public class Importer : ITextToPoco
    {
        private readonly IImporter _importer;

        public Importer(IImporter importer)
        {
            _importer = importer;
        }

        public event EventHandler<WarningEventArgs> Warning;

        public IEnumerable<T> Run<T>(IDbContext context, ITextToPocoArgs args, Func<T, T> update = null) where T : class, new()
        {
            var entities = _importer.Import<T>(context, args, update);

            RaiseWarnings(_importer.Exceptions);

            return entities;
        }

        public IEnumerable<IEnumerable<T>> Run<T>(IDbContext context, ITextToPocoArgs args, int batchSize, Func<T, T> update = null) where T : class, new()
        {
            foreach (var batch in _importer.Import<T>(context, args, batchSize, update))
            {
                yield return batch;
            }
            RaiseWarnings(_importer.Exceptions);
        }

        protected virtual void OnWarning(WarningEventArgs e)
        {
            EventHandler<WarningEventArgs> warningEvent = Warning;

            if (warningEvent == null)
                throw new Exception("You need to subscribe to TextToPoco Importer warning event");

            EventHandler<WarningEventArgs> handler = warningEvent;
            handler.Invoke(this, e);
        }

        private void RaiseWarnings(List<Exception> warnings)
        {
            var beginMessage = "";
            foreach (var error in warnings)
            {
                if (beginMessage != error.Message)
                {
                    beginMessage = error.Message;
                    OnWarning(new WarningEventArgs(error.Message));
                }
            }
        }
    }
}
