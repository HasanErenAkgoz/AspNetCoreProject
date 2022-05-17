using Business.Abstract;
using Business.Concrate;
using DataAccess.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            using (var Context = new Context())
            {
                var userName = User.Identity.Name;
                var userMail = Context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();

                var writerId = Context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
                var totalBlogCount = blogManager.GetList().Count().ToString();
                ViewBag.totalBlogCount = totalBlogCount;

                var WriterTotalBlogCount = blogManager.GetList().Where(x => x.WriterId == writerId).Count();
                ViewBag.WriterTotalBlogCount = WriterTotalBlogCount;

                var TotalCategoryCount = categoryManager.GetList().Count();
                ViewBag.TotalCategoryCount = TotalCategoryCount;
            }


            return View();
        }
    }
}
