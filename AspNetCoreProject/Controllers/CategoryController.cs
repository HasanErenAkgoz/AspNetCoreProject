using Business.Abstract;
using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;


namespace AspNetCoreProject.Controllers
{
    public class CategoryController : Controller
    {

        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            var result = categoryManager.GetList();
            return View(result);
        }
    }
}
