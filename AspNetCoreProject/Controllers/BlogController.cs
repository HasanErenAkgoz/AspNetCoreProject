using Business.Concrate;
using Business.ValidationRules;
using DataAccess.Concrate;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
     
        [AllowAnonymous]

        public IActionResult Index()
        {
            var result = blogManager.GetBlogListWithCategory();
            return View(result);
        }
        [AllowAnonymous]

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.id = id;
            var result = blogManager.GetById(id);
            return View(result);
        }
        [AllowAnonymous]
        public IActionResult BlogListByWriter()
        {
            using (Context context = new Context())
            {
                var userName = User.Identity.Name;
                var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
                var userId = context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
                var result = blogManager.GetListWritCategoryByWriter(userId);
                return View(result);
            }
        }
        [HttpGet]
        public IActionResult Add()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            WriterManager writerManager = new WriterManager(new EfWriterDal());

            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.categoryValues = categoryValues;


            return View();
        }
        [HttpPost]
        public IActionResult Add(Blog blog)
        {
            using (Context context = new Context())
            {

                var userName = User.Identity.Name;
                var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
                var userId = context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
                BlogValidator blogValidator = new BlogValidator();
            ValidationResult validationResult = blogValidator.Validate(blog);
            if (validationResult.IsValid)
            {
                blog.Status = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = userId;
                blogManager.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();

            }
            }
        }
        public IActionResult Delete(int id)
        {
            var result = blogManager.GetList().Find(x => x.Id == id);
            if (result.Status == true)
            {
                result.Status = false;
                blogManager.Update(result);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else if (result.Status == false)
            {
                result.Status = true;
                blogManager.Update(result);
                return RedirectToAction("BlogListByWriter", "Blog");
            }

            return RedirectToAction("BlogListByWriter", "Blog");



        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {

            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.categoryValues = categoryValues;

            var result = blogManager.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            using (Context context = new Context())
            {
                var userName = User.Identity.Name;
                var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
                var userId = context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
                List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.Id.ToString()
                                                       }).ToList();
                ViewBag.categoryValues = categoryValues;
                blog.WriterId = userId;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blogManager.Update(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }

        }
    }
}
