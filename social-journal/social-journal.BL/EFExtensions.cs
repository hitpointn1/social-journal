﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using social_journal.Base;
using social_journal.Base.Loggers;
using social_journal.DL;
using social_journal.DL.Entities;

namespace social_journal.BL
{
    public static class EFExtensions
    {
        public static IServiceCollection ConfigureSQLServer(this IServiceCollection services, IConfiguration configuration)
        {
#if DEBUG
            var connection = configuration["ConnectionString"];
#else
            var connection = configuration["ConnectionString"];
#endif

            services.AddDbContext<MainDBContext>(options =>
                options.UseSqlServer(connection)
            );

            return services;
        }

        public static IServiceCollection AddPostsRepository(this IServiceCollection services)
        {
            services.AddSingleton<ILog, Logger>();
            services.AddScoped<IBaseContext, MainAppContext>();
            services.AddScoped<IAsyncRepository<Post>, BaseRepository<Post, IBaseContext>>();
            return services;
        }
    }
}
