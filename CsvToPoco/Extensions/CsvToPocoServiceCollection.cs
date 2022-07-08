using Microsoft.Extensions.DependencyInjection;
using TextToPoco.Core;
using TextToPoco.Services;

namespace CsvToPoco.Extensions
{
    public static class CsvToPocoServiceCollection
    {
        public static IServiceCollection AddCsvToPoco(this IServiceCollection services)
        {
            services.AddScoped<IObjectifier, Objectifier>();
            services.AddScoped<IImporter, TextImporter>();
            services.AddScoped<ITextToPoco, Importer>();
            return services;
        }
    }
}
