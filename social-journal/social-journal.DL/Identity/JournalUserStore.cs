using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace social_journal.DL.Identity
{
    public class JournalUserStore : UserStore<JournalUser>
    {
        public JournalUserStore(JournalDBContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
        }
    }
}
