using Microsoft.EntityFrameworkCore;

namespace social_journal.Base.EFRImplementation
{
    /// <summary>
    /// UoW-Pattern
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class BaseRepositoryProvider<TAppContext, TDBContext> : IRepositoryProvider<TAppContext, TDBContext>
        where TDBContext : DbContext
        where TAppContext : IBaseContext<TDBContext>
    {
        public TAppContext Context { get; set; }

        public BaseRepositoryProvider(TAppContext context)
        {
            Context = context;
        }
    }
}
