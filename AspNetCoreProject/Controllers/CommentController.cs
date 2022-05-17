using Business.Abstract;
using Business.Concrate;
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
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentDal());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComment(Comment comment)
        {
            comment.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.Status = true;
            comment.BlogId = 9;
            _commentManager.Add(comment);
            return RedirectToAction("BlogReadAll", "Blog", new { id = comment.BlogId });
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            var values = _commentManager.GetList(id);
            return PartialView(values);
        }
    }
}
