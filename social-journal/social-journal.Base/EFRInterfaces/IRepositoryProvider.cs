using Microsoft.EntityFrameworkCore;

namespace social_journal.Base
{
    public interface IRepositoryProvider<TDBContext>
        where TDBContext : DbContext
    {
        TDBContext DbContext { get; set; }
        ILog Logger { get; set; }
    }
}
