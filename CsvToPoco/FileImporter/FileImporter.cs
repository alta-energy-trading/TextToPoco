using System.IO;
using CsvHelper.Configuration;
using System.Collections.Generic;
using CsvToPoco;
using System;

namespace CsvToPoco
{
    public class FileImporter : IFileImporterService
    {
        private readonly ITextToPoco _textToPoco;
        private readonly IDbContext _dbContext;
        private readonly IPocoLocoCleaner _pocoLocoCleaner;

        public FileImporter(ITextToPoco textToPoco, IDbContext dbContext, IPocoLocoCleaner pocoLocoCleaner)
        {
            _textToPoco = textToPoco;
            _dbContext = dbContext;
            _pocoLocoCleaner = pocoLocoCleaner;

            _textToPoco.Warning += _textToPoco_Warning;
        }

        public IEnumerable<T> Import<T>(Stream stream, ClassMap classMap) where T : class, new()
        {            
            CsvToPocoArgs args = new CsvToPocoArgs()
            {
                Stream = stream,
                Delimiter = ",",
                HasHeaders = true,
                ClassMap = classMap,
                PersistAction = PersistActionEnum.Add
            };

            var items = _textToPoco.Run<T>(_dbContext, args);
            return items;
        }

        private void _textToPoco_Warning(object sender, WarningEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
