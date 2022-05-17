 using AspNetCoreProject.Models;
using Business.Concrate;
using Business.ValidationRules;
using DataAccess.Concrate;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Controllers
{

    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        private readonly UserManager<AppUser> _userManager;
        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.userMail = userMail;

         
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult Text()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
                var result = await _userManager.FindByNameAsync(User.Identity.Name);
                UserUpdateViewModel userUpdateViewModel = new UserUpdateViewModel();
                userUpdateViewModel.email = result.Email;
                userUpdateViewModel.namesurnam = result.NameSurname;
                userUpdateViewModel.username = result.UserName;
            userUpdateViewModel.password = result.PasswordHash;
            return View(userUpdateViewModel);
        } 

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddProfileImage addProfileImage)
        {
            Writer writer = new Writer();
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult validationResult = writerValidator.Validate(writer);
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
            writerManager.Add(writer);
            return View();

        }
        [AllowAnonymous]

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel userUpdateViewModel)
        {

            var result = await _userManager.FindByNameAsync(User.Identity.Name);

            result.NameSurname = userUpdateViewModel.namesurnam;
            result.Email = userUpdateViewModel.email;
            result.UserName = userUpdateViewModel.username;
            result.PasswordHash = _userManager.PasswordHasher.HashPassword(result, userUpdateViewModel.password);

            var values = await _userManager.UpdateAsync(result);
              return RedirectToAction("WriterEditProfile", "Writer");

        }


        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }

    }
}
