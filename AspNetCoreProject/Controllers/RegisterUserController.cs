﻿using AspNetCoreProject.Models;
using Entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSıgnUpViewModel signUpViewModel)
        {
            if (!signUpViewModel.IsAcceptTheContract)
            {
                ModelState.AddModelError("IsAcceptTheContract",
                    "Sayfamıza kayıt olabilmek için gizlilik sözleşmesini kabul etmeniz gerekmektedir.");
                return View(signUpViewModel);
            }
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Email = signUpViewModel.Mail,
                    UserName = signUpViewModel.UserName,
                    NameSurname = signUpViewModel.NameSurname
                };

                var result = await _userManager.CreateAsync(user, signUpViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(signUpViewModel);
        }
    }
}
