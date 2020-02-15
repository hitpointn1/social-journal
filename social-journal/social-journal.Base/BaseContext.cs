using Microsoft.EntityFrameworkCore;

namespace social_journal.Base
{
    public class BaseContext<TContext> : IBaseContext<TContext>
        where TContext : DbContext
    {
        public BaseContext(ILog logger, TContext eFContext)
        {
            Logger = logger;
            EFContext = eFContext;
        }

        public ILog Logger { get; set; }
        public TContext EFContext { get; set; }
    }
}