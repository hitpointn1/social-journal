using Microsoft.EntityFrameworkCore;

namespace social_journal.Base.EFRImplementation
{
    /// <summary>
    /// UoW-Pattern
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class BaseRepositoryProvider<TDBContext> : IRepositoryProvider<TDBContext>
        where TDBContext : DbContext
    {
        public TDBContext DbContext { get; set; }
        public ILog Logger { get; set; }

        public BaseRepositoryProvider(TDBContext context, ILog logger)
        {
            DbContext = context;
            Logger = logger;
        }
    }
}
