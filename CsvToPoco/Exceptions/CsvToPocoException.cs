using System;

namespace CsvToPoco.Exceptions
{
    public class CsvToPocoException : Exception
    {
        public string FileName { get; set; }
        public Exception Exception { get; set; }

        public CsvToPocoException(string fileName, Exception exception) : base()
        {
            FileName = fileName;
            Exception = exception;
        }
    }
}
