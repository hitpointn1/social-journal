using social_journal.BL.DTO;
using social_journal.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace social_journal.BL.Services.Implementation
{
    public class MockService : IJournalProfileService
    {
        public Task<IEnumerable<AchievementDTO>> GetUserAchievements()
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
            return Task.FromResult(fakeAchievements.AsEnumerable());
        }

        public Task<IEnumerable<PostDTO>> GetUserPosts()
        {
            var fakePosts = new List<PostDTO>
            {
                new PostDTO()
                {
                    Created = DateTime.Now.AddDays(-1).AddHours(-1),
                    ID = 0,
                    Content = "asdadasdasdsad",
                    LastUpdated = DateTime.Now.AddHours(-1),
                    Title = "FirstPost"
                },
                new PostDTO()
                {
                    Created = DateTime.Now.AddDays(-1),
                    ID = 1,
                    Content = "asdadasdasdsad",
                    LastUpdated = DateTime.Now,
                    Title = "SecondPostPost"
                },
            };
            return Task.FromResult(fakePosts.AsEnumerable());
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
