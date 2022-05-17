using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager notificationManager = new NotificationManager(new EfNotificationDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllNotification()
        {
            var result = notificationManager.GetList();
            return View(result);
        }
    }
}
