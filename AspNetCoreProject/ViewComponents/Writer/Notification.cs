using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.ViewComponents.Writer
{
    public class Notification:ViewComponent
    {

        NotificationManager notificationManager = new NotificationManager(new EfNotificationDal());
        public IViewComponentResult Invoke()
        {
            var result = notificationManager.GetList();
            return View(result);
        }
    }
}
