using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {

        BlogManager blogManager = new BlogManager(new EfBlogDal());
        public IViewComponentResult Invoke()
        {
            var recentlyAddedBlog = blogManager.GetList().OrderByDescending(x=>x.Id).Select(x=>x.Title).Take(1).FirstOrDefault();
            ViewBag.recentlyAddedBlog = recentlyAddedBlog;
            return View();
        }
    }
}
