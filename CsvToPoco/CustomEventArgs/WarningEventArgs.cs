using System;

namespace CsvToPoco
{
    public class WarningEventArgs : EventArgs
    {
        public string Message { get; set; }
        public WarningEventArgs(string message) : base()
        {
            Message = message;

        }
    }
}