﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public LoginController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult SignUp() => View();

		[HttpPost]
		public async Task<IActionResult> SignUp(UserRegisterViewModel userRegisterViewModel)
		{
			AppUser appUser = new AppUser()
			{
				Name = userRegisterViewModel.Name,
				SurName = userRegisterViewModel.SurName,
				UserName = userRegisterViewModel.UserName,
				Email = userRegisterViewModel.Mail,
			};

			var result = await _userManager.CreateAsync(appUser, userRegisterViewModel.Password);

			if (result.Succeeded) return RedirectToAction("SignIn");			
			else foreach (var item in result.Errors) ModelState.AddModelError("",item.Description);

			return View(userRegisterViewModel);
		}

		[HttpGet]
		public IActionResult SignIn() => View();

		/*[HttpPost]
        public IActionResult SignIn()
        {
            return View();
        }*/
	}
}
