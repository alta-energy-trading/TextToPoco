using CsvHelper;
using System;

namespace CsvToPoco.Exceptions
{
    public class CsvToPocoException : ReaderException
    {
        public CsvToPocoException(CsvContext context) : base(context)
        {
        }

        public CsvToPocoException(CsvContext context, string message) : base(context, message)
        {
        }

        public CsvToPocoException(CsvContext context, string message, Exception innerException) : base(context, message, innerException)
        {
        }

        public string FileName { get; set; }
    }
}