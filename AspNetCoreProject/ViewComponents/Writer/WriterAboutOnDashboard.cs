using Business.Concrate;
using DataAccess.Concrate;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.ViewComponents.Writer
{

    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        private readonly UserManager<AppUser> userManager;
        public WriterAboutOnDashboard(UserManager<AppUser> manager)
        {
            userManager = manager;
        }
        public IViewComponentResult Invoke()
        {
            using (var context = new Context())
            {
                var userName = User.Identity.Name;
               
                var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
                var userId = context.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
                var result = writerManager.GetWriterById(userId);
                return View(result);
            }

        }
    }
}
