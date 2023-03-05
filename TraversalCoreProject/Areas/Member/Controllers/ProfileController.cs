using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using TraversalCoreProject.Areas.Member.Models;
using TraversalCoreProject.Methods;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            UserEditViewModel userEditViewModel = new UserEditViewModel();

            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            userEditViewModel.name = values.Name;
            userEditViewModel.surName = values.SurName;
            userEditViewModel.mail = values.Email;
            userEditViewModel.phoneNumber = values.PhoneNumber;
            userEditViewModel.ImageUrl = values.ImageUrl;

            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel,IFormFile FileUrl)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            if (FileUrl != null) user.ImageUrl = FileService.CreateToIFormFile(FileUrl);    
            else user.ImageUrl = userEditViewModel.ImageUrl;

            user.Name = userEditViewModel.name;
            user.SurName = userEditViewModel.surName;
            user.PhoneNumber = userEditViewModel.phoneNumber;
            user.Email = userEditViewModel.mail;

            if (userEditViewModel.password != null) _userManager.PasswordHasher.HashPassword(user,userEditViewModel.password);

            var result = await _userManager.UpdateAsync(user);

            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            userEditViewModel.name = values.Name;
            userEditViewModel.surName = values.SurName;
            userEditViewModel.mail = values.Email;
            userEditViewModel.phoneNumber = values.PhoneNumber;
            userEditViewModel.ImageUrl = values.ImageUrl;

            return View(userEditViewModel);


        }

    }
}
