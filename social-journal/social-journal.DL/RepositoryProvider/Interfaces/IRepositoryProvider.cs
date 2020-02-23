using Microsoft.EntityFrameworkCore;
using social_journal.Base;

namespace social_journal.DL.RepositoryProvider
{
    public interface IRepositoryProvider<TDBContext>
        where TDBContext : DbContext
    {
        TDBContext DbContext { get; set; }
        ILog Logger { get; set; }
    }
}
