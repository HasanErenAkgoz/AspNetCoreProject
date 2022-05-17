using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
     
        public IActionResult Index()
        {
            CommentManager commentManager = new CommentManager(new EfCommentDal());
            var values = commentManager.GetList();
            return View(values);
          
        }
    }
}
