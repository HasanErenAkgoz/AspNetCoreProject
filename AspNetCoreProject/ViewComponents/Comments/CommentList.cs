using AspNetCoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    Id=1,
                    UserName="Eren"
                },
                new UserComment
                {
                    Id=2,
                    UserName="Murat"
                },
                new UserComment
                {
                    Id=3,
                    UserName="Ecem"
                },
                new UserComment
                {
                    Id=4,
                    UserName="Merve"
                },
            };
            return View(commentValues);
        }
    }
}
