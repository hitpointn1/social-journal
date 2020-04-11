using Microsoft.AspNetCore.Mvc;
using social_journal.BL.Services.Interfaces;
using social_journal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace social_journal.ViewComponents
{
    public class PostsFeedViewComponent : ViewComponent
    {
        private readonly IJournalProfileService service;

        public PostsFeedViewComponent(IJournalProfileService service)
        {
            this.service = service;
        }

        public IViewComponentResult Invoke()
        {
            var postsDtos = service.GetUserPosts().GetAwaiter().GetResult();
            var postsVms = postsDtos.Select(dto => new PostVM()
            {
                Content = dto.Content,
                CreatedDate = dto.Created,
                ID = dto.ID,
                Title = dto.Title
            });
            return View(postsVms);
        }
    }
}
