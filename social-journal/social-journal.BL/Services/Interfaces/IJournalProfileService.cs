using social_journal.BL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace social_journal.BL.Services.Interfaces
{
    public interface IJournalProfileService
    {
        Task<ProfileDTO> GetUserProfile();
        Task<IEnumerable<AchievementDTO>> GetUserAchievements();
        Task<IEnumerable<PostDTO>> GetUserPosts();
    }
}
