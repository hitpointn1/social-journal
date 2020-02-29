using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace social_journal.DL.Identity
{
    public class JournalUserManager : UserManager<JournalUser>
    {
        public JournalUserManager(IUserStore<JournalUser> store, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<JournalUser> passwordHasher, IEnumerable<IUserValidator<JournalUser>> userValidators,
            IEnumerable<IPasswordValidator<JournalUser>> passwordValidators, ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<JournalUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }
}
