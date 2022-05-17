using Business.Concrate;
using DataAccess.Abstract;
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
    public class ContactController : Controller
    {

        ContactManager _contactManager = new ContactManager(new EfContactDal());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.Status = true;
            _contactManager.Add(contact);
            return RedirectToAction("Index","Blog");
        }
    }
}
