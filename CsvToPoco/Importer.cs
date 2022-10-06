using CsvToPoco.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

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

            RaiseWarnings(((FileStream)args.Stream).Name, _importer.Exceptions);

            return entities;
        }

        public IEnumerable<IEnumerable<T>> Run<T>(IDbContext context, ITextToPocoArgs args, int batchSize, Func<T, T> update = null) where T : class, new()
        {
            foreach (var batch in _importer.Import<T>(context, args, batchSize, update))
            {
                yield return batch;
            }
            RaiseWarnings(((FileStream)args.Stream).Name, _importer.Exceptions);
        }

        protected virtual void OnWarning(WarningEventArgs e)
        {
            EventHandler<WarningEventArgs> warningEvent = Warning;

            if (warningEvent == null)
                throw new Exception("You need to subscribe to TextToPoco Importer warning event");

            EventHandler<WarningEventArgs> handler = warningEvent;
            handler.Invoke(this, e);
        }

        private void RaiseWarnings(string fileName, List<Exception> exceptions)
        {
            var beginMessage = "";
            foreach (var exception in exceptions)
            {
                if (beginMessage != exception.Message)
                {
                    beginMessage = exception.Message;
                    CsvToPocoException csvToPocoException = (CsvToPocoException)exception;
                    csvToPocoException.FileName = fileName;
                    OnWarning(new WarningEventArgs(csvToPocoException));
                }
            }
        }
    }
}