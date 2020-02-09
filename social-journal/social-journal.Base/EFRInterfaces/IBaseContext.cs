using Microsoft.EntityFrameworkCore;

namespace social_journal.Base
{
    public interface IBaseContext
    {
        ILog Logger { get; set; }
        DbContext EFContext { get; set; }
    }
}
