using social_journal.BL.DTO;
using social_journal.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace social_journal.BL.Services.Implementation
{
    public class MockService : IJournalProfileService
    {
        public Task<List<AchievementDTO>> GetUserAchievements()
        {
            var fakeAchievements = new List<AchievementDTO>
            {
                new AchievementDTO()
                {
                    Title = "Первый пост",
                    Description = "Пользователь написал первый пост"
                },
                new AchievementDTO()
                {
                    Title = "Первый комментарий",
                    Description = "Пользователь написал первый комментарий"
                }
            };
            return Task.FromResult(fakeAchievements);
        }

        public Task<ProfileDTO> GetUserProfile()
        {
            var fakeProfile = new ProfileDTO()
            {
                ID = 1,
                Birthday = DateTime.Now,
                Country = "Russia",
                Title = "Nickolay Pushkin",
                Survey = "Blog about programming etc etc etc etc etc etcetc etc etcetc etc etcetc etc etcetc etc etcetc etc etc",
            };
            return Task.FromResult(fakeProfile);
        }
    }
}
