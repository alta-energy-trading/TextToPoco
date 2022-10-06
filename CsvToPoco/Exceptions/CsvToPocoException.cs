using CsvHelper;
using System;

namespace CsvToPoco.Exceptions
{
    public class CsvToPocoException : ReaderException
    {
        public string FileName { get; set; }
        public Exception Exception { get; set; }

        public CsvToPocoException(CsvContext context, string fileName, Exception exception) : base(context, exception.Message)
        {
            FileName = fileName;
            Exception = exception;
        }
    }
}