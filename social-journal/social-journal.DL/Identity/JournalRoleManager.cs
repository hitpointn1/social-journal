using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace social_journal.DL.Identity
{
    public class JournalRoleManager : RoleManager<JournalRole>
    {
        public JournalRoleManager(IRoleStore<JournalRole> store,
            IEnumerable<IRoleValidator<JournalRole>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<RoleManager<JournalRole>> logger)
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
