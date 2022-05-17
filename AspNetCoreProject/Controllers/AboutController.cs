using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public IActionResult Index()
        {
            var result = aboutManager.GetList();

            return View(result);
        }

        public PartialViewResult SocialMediaAbout()
        {
            return PartialView(); 
        }
    }
}
