using Microsoft.EntityFrameworkCore;

namespace social_journal.Base
{
    public interface IRepositoryProvider<TAppContext, TDBContext>
        where TDBContext : DbContext
        where TAppContext : IBaseContext<TDBContext>
    {
        TAppContext Context { get; set; }
    }
}
