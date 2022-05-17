using Business.Abstract;
using Business.Concrate;
using DataAccess.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public IViewComponentResult Invoke()
        {
            var result = adminManager.GetById(1);
                     return View(result);
        }
    }
}
