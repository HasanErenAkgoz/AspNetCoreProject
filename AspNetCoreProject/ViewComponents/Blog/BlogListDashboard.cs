using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        private BlogManager _blogManager = new BlogManager(new EfBlogDal());

        public IViewComponentResult Invoke()
        {
            var blogs = _blogManager.GetBlogListWithCategory();
            return View(blogs);
        }
    }
}
