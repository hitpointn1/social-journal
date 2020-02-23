using Microsoft.EntityFrameworkCore;
using social_journal.Base;
using social_journal.DL.RepositoryProvider;

namespace social_journal.DL.AppContext
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
