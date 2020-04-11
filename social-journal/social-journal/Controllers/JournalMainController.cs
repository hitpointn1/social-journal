using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using social_journal.BL.DTO;
using social_journal.BL.Services.Interfaces;
using social_journal.Models;

namespace social_journal.Controllers
{
    public class JournalMainController : BaseJournalController
    {
        private readonly IJournalProfileService service;

        public JournalMainController(IJournalProfileService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> JournalPage()
        {
            List<AchievementDTO> achievementsDtos = await service.GetUserAchievements();
            IEnumerable<AchievementVM> achievementsVMs = achievementsDtos.Select(item => new AchievementVM() { Description = item.Description, Title = item.Title });
            ProfileDTO profileDto = await service.GetUserProfile();
            ProfileVM profileVM = new ProfileVM()
            {
                Achievements = achievementsVMs,
                ID = profileDto.ID,
                Title = profileDto.Title,
                Country = profileDto.Country,
                Birthday = profileDto.Birthday.HasValue
                    ? profileDto.Birthday.Value.ToLongDateString()
                    : string.Empty,
                Survey = profileDto.Survey
            };
            return View(profileVM);
        }
    }
}