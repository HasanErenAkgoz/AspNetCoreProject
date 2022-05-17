using AspNetCoreProject.Models;
using Business.Abstract;
using Business.Concrate;
using Business.ValidationRules;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterCityModel writerCity = new WriterCityModel();

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Cities = writerCity.GetCityList();
            return View();
        }
        [HttpPost]

        public IActionResult Index(AddProfileImage addProfileImage, string PasswordAgain)
        {

            Writer writer = new Writer();
            
            if (addProfileImage.Image != null)
            {
                var extension = Path.GetExtension(addProfileImage.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                addProfileImage.Image.CopyTo(stream);
                writer.Image = newImageName;
            }
            writer.Mail = addProfileImage.Mail;
            writer.Password = addProfileImage.Password;
            writer.Name = addProfileImage.Name;
            writer.Status = true;
            writer.About = addProfileImage.About;
            writer.City = addProfileImage.City;
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult validationResult = writerValidator.Validate(writer);
            if (validationResult.IsValid && writer.Password == PasswordAgain)
            {
                writer.Status = true;
                writerManager.Add(writer);
                return RedirectToAction("Index", "Blog");
            }
            else if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            ViewBag.Cities = writerCity.GetCityList();

            return View();
            //WriterValidator writerValidator = new WriterValidator();
            //ValidationResult validationResult = writerValidator.Validate(writer);
            //if (validationResult.IsValid && writer.Password == PasswordAgain)
            //{
            //    writer.Status = true;
            //    writerManager.Add(writer);
            //    return RedirectToAction("Index", "Blog");
            //}

            //else
            //{
            //    ModelState.AddModelError("WriterPassword", "Girdiğiniz Şifreler Eşleşmiyor! Lütfen Tekrar Deneyiniz");
            //}
            //ViewBag.Cities = writerCity.GetCityList();
            //return View();
        }
    }
}
