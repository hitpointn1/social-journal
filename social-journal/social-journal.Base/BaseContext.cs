using Microsoft.EntityFrameworkCore;

namespace social_journal.Base
{
    public class BaseContext : IBaseContext
    {
        public BaseContext(ILog logger, DbContext eFContext)
        {
            Logger = logger;
            EFContext = eFContext;
        }

        public ILog Logger { get; set; }
        public DbContext EFContext { get; set; }
    }
}