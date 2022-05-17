using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Controllers
{
    [AllowAnonymous]
    public class NewLetter : Controller
    {
        NewsLetterManager newsLetterManager = new NewsLetterManager(new EfNewsLetter());
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView ();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter newsLetter)
        {

            newsLetter.Status = true;
            newsLetterManager.Add(newsLetter);
            return RedirectToAction("Index", "Blog");

        }
    }
}
