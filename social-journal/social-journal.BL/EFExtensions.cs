using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using social_journal.Base;
using social_journal.Base.Loggers;
using social_journal.DL;
using social_journal.DL.Interfaces;

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

            services.AddDbContext<JournalDBContext>(options =>
                options.UseSqlServer(connection)
            );

            return services;
        }

        public static IServiceCollection AddRepositoryProvider(this IServiceCollection services)
        {
            services.AddSingleton<ILog, Logger>();
            services.AddScoped<IJournalRepositoryProvider, JournalRepositoryProvider>();
            services.AddScoped<IJournalAppContext, JournalAppContext>();
            return services;
        }
    }
}
