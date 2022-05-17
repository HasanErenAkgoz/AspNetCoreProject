using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AspNetCoreProject.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactManager contactManager = new ContactManager(new EfContactDal());
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke()
        {
            string api = "83e229968d0ec0b154fd24b94ef59836";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument document=XDocument.Load(connection);  

            var blogCount = blogManager.BlogCount();
            ViewBag.blogCount = blogCount;

            var contactCount = contactManager.ContactCount();
            ViewBag.contactCount = contactCount;

            var commentCount = commentManager.CommentCount();
            ViewBag.commentCount = commentCount;

            var temperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            Math.Ceiling(decimal.Parse(temperature));
            ViewBag.temperature = temperature;

            return View();
        }
    }
}
