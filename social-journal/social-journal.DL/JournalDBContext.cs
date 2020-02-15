using Microsoft.EntityFrameworkCore;
using social_journal.DL.Entities;

namespace social_journal.DL
{
    public class JournalDBContext : DbContext
    {
        public JournalDBContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
    }
}
