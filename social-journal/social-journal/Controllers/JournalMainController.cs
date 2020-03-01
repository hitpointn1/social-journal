using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using social_journal.Models.ViewModels;

namespace social_journal.Controllers
{
    public class JournalMainController : BaseJournalController
    {
        public IActionResult JournalPage()
        {
            var fakeData = new ProfileVM()
            {
                ID = 1,
                Birthday = DateTime.Now.ToLongDateString(),
                Country = "Russia",
                Title = "Nickolay Pushkin",
                Survey = "Blog about programming etc etc etc etc etc etcetc etc etcetc etc etcetc etc etcetc etc etcetc etc etc"
            };
            return View(fakeData);
        }
    }
}