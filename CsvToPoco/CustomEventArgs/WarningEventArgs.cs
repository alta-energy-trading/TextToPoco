using CsvToPoco.Exceptions;
using System;

namespace CsvToPoco
{
    public class WarningEventArgs : EventArgs
    {
        public CsvToPocoException Exception { get; set; }
        public WarningEventArgs(CsvToPocoException exception) : base()
        {
            Exception = exception;
        }
    }
}