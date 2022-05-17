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
    public class MessageNotification:ViewComponent
    {
        MessageTwoManager messageManager = new MessageTwoManager(new EfMessageTwoDal());
        private UserManager<AppUser> _userManager;
            public MessageNotification(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            using (var context=new Context())
            {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var userId = context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
            var result = messageManager.GetInboxByWriter(userId);
            return View(result);
            }
        }
    }
}
