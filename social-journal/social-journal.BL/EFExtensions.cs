using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using social_journal.Base;
using social_journal.Base.Loggers;
using social_journal.DL.AppContext;
using social_journal.DL.RepositoryProvider;
using social_journal.DL;
using social_journal.DL.Identity;
using System;

namespace social_journal.BL
{
    public static class EFExtensions
    {
        public static IServiceCollection ConfigureSQLServer(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));
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

        public static IServiceCollection InjectJournalContext(this IServiceCollection services)
        {
            services.AddSingleton<ILog, Logger>();
            services.AddScoped<IJournalRepositoryProvider, JournalRepositoryProvider>();

            services.AddIdentityCore<JournalUser>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddUserStore<JournalUserStore>()
                .AddUserManager<JournalUserManager>()
                .AddRoles<JournalRole>()
                .AddRoleStore<JournalRoleStore>()
                .AddRoleManager<JournalRoleManager>();

            services.AddScoped<IJournalAppContext, JournalAppContext>();
            return services;
        }
    }
}
