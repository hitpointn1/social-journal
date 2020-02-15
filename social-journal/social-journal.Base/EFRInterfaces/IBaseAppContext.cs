using Microsoft.EntityFrameworkCore;

namespace social_journal.Base
{
    public interface IBaseAppContext<TDBContext, TProvider>
        where TDBContext : DbContext
        where TProvider : IRepositoryProvider<TDBContext>
    {
        ILog Logger { get; set; }
        TDBContext EFContext { get; set; }
        TProvider RepositoryProvider { get; set; }
    }
}
