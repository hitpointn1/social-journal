using Microsoft.EntityFrameworkCore;
using social_journal.Base;

namespace social_journal.DL.RepositoryProvider
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
