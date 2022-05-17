using Business.Concrate;
using System;
using DataAccess.Concrate;
using Entity.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminMessageController : Controller
    {
        MessageTwoManager mm = new MessageTwoManager(new EfMessageTwoDal());
        Context c = new Context();

        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.Mail == usermail).Select(y => y.Id).FirstOrDefault();
            var values = mm.GetInboxByWriter(writerID);
            if (values.Count() > 3)
            {
                values = values.TakeLast(3).ToList();
            }
            return View(values);
        }

        public IActionResult Sendbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.Mail == usermail).Select(y => y.Id).FirstOrDefault();
            var values = mm.GetSendboxWithByWriter(writerID);
            if (values.Count() > 3)
            {
                values = values.TakeLast(3).ToList();
            }
            return View(values);
        }

        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }
        public IActionResult ComposeMessage(MessageTwo message)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.Mail == usermail).Select(y => y.Id).FirstOrDefault();
            message.Sender = writerID;
            message.Receviver = 2;
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.Status = true;
            mm.Add(message);
            return RedirectToAction("SendBox");
        }
    }
}

