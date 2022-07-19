﻿using Microsoft.Extensions.DependencyInjection;

namespace CsvToPoco.Extensions
{
    public static class PocoLocoServiceCollection
    {
        public static IServiceCollection AddPocoLoco(this IServiceCollection services)
        {
            services.AddScoped<ICleaner, CleanerService>();
            services.AddScoped<IPocoLocoCleaner, Cleaner>();
            return services;
        }
    }
}
