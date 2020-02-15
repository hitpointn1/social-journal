using Microsoft.EntityFrameworkCore;

namespace social_journal.Base
{
    public interface IBaseContext<TContext>
        where TContext : DbContext
    {
        ILog Logger { get; set; }
        TContext EFContext { get; set; }
    }
}
