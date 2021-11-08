using System;

namespace TextToPoco
{
    public interface ITextToPoco
    {
        event EventHandler<WarningEventArgs> Warning;
        void Run<T>(IDbContext context, IClientImporter importerArg) where T : class, IDirty, new();
    }
}
