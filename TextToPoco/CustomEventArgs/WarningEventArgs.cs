using System;

namespace TextToPoco.Core
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
