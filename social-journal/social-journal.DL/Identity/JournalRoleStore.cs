using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace social_journal.DL.Identity
{
    public class JournalRoleStore : RoleStore<JournalRole>
    {
        public JournalRoleStore(JournalDBContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
        }
    }
}
