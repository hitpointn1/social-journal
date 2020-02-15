using Microsoft.EntityFrameworkCore;

namespace social_journal.Base
{
    public class BaseContext<TContext, TProvider> : IBaseAppContext<TContext, TProvider>
        where TContext : DbContext
        where TProvider : IRepositoryProvider<TContext>
    {
        public BaseContext(ILog logger, TContext eFContext, TProvider repositoryProvider)
        {
            Logger = logger;
            EFContext = eFContext;
            RepositoryProvider = repositoryProvider;
        }

        public ILog Logger { get; set; }
        public TContext EFContext { get; set; }
        public TProvider RepositoryProvider { get; set; }
    }
}