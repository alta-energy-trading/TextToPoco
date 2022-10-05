using System;

namespace CsvToPoco
{
    public class WarningEventArgs : EventArgs
    {
        public string Message { get; set; }
        public WarningEventArgs(string fileName, string message) : base()
        {
            Message = $"The File: {fileName}\n had the following error:\n {message}";
        }
    }
}