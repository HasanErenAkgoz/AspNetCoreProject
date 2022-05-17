using Business.Abstract;
using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.ViewComponents.Category
{
    public class CategoryList:ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IViewComponentResult Invoke()
        {
            var result = categoryManager.GetList();
            return View(result);
        }
    }
}
