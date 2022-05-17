using AspNetCoreProject.Areas.Admin.Models;
using Business.Concrate;
using ClosedXML.Excel;
using DataAccess.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());

        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
       
        public IActionResult BlogListExcel()
        {
            return View();
        }
    }
}

