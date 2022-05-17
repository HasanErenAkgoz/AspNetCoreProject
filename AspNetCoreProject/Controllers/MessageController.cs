using Business.Concrate;
using DataAccess.Concrate;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Controllers
{
    public class MessageController : Controller
    {
        MessageTwoManager messageTwoManager = new MessageTwoManager(new EfMessageTwoDal());
        public IActionResult Inbox()
        {
            using (var context=new Context())
            {
                var usernamme = User.Identity.Name;
                var usermail = context.Users.Where(x => x.UserName == usernamme).Select(y => y.Email).FirstOrDefault();
                var writerId = context.Writers.Where(x => x.Mail == usermail).Select(y=>y.Id).FirstOrDefault();
                var result = messageTwoManager.GetInboxByWriter(writerId);
                return View(result);
            }
          
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {

            var result = messageTwoManager.GetById(id);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            List<SelectListItem> recieverUsers = (from x in await GetUsersAsync()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Email.ToString(),
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.RecieverUser = recieverUsers;
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(MessageTwo messageTwo)
        {
            using (var context = new Context())
            {


                var usernamme = User.Identity.Name;
                var usermail = context.Users.Where(x => x.UserName == usernamme).Select(y => y.Email).FirstOrDefault();
                var writerId = context.Writers.Where(x => x.Mail == usermail).Select(y => y.Id).FirstOrDefault();
                messageTwo.Sender = writerId;
                messageTwo.Receviver = 2;
                messageTwo.Status = true;
                messageTwo.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                messageTwoManager.Add(messageTwo);

                return RedirectToAction("Inbox", "Message");
            }
        }
        public IActionResult SendBox()
        {
            using (var context=new Context())
            {
                var usernamme = User.Identity.Name;
                var usermail = context.Users.Where(x => x.UserName == usernamme).Select(y => y.Email).FirstOrDefault();
                var writerId = context.Writers.Where(x => x.Mail == usermail).Select(y => y.Id).FirstOrDefault();
                var result = messageTwoManager.GetSendboxWithByWriter(writerId);
                return View(result);

            }
        }
        public async Task<List<AppUser>> GetUsersAsync()
        {
            using (var context = new Context())
            {
                return await context.Users.ToListAsync();
            }
        }
    }
}
