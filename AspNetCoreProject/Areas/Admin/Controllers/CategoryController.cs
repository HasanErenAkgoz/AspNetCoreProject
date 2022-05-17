using Business.Concrate;
using Business.ValidationRules;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace AspNetCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public IActionResult Index(int page=1)
        {
            var values = categoryManager.GetList().ToPagedList(page,5);
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                category.Status = true;
                categoryManager.Add(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();

        }
        public IActionResult Delete(int id)
        {
            var result = categoryManager.GetById(id);
            categoryManager.Delete(result);
            return RedirectToAction("Index", "Category");
        }
    }
}
