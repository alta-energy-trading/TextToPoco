﻿using Microsoft.Extensions.DependencyInjection;
using TextToPoco.Core;
using TextToPoco.Services;

namespace JsonToPoco.Extensions
{
    public static class CsvToPocoServiceCollection
    {
        public static IServiceCollection AddCsvToPoco(this IServiceCollection services)
        {
            services.AddScoped<IObjectifier, Objectifier>();
            return services;
        }
    }
}
