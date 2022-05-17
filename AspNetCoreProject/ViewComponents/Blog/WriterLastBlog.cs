using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.ViewComponents.Blog
{
    public class WriterLastBlog: ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        public IViewComponentResult Invoke()
        {
            var result = blogManager.GetBlogByWriter(1);
            return View(result);
        }

    }
}
