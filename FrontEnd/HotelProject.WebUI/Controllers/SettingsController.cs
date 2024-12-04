using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Setting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user= await _userManager.FindByNameAsync(User.Identity.Name);   
            UserEditViewModel userEditViewModel= new UserEditViewModel();
            
            userEditViewModel.UserName = user.UserName;
            userEditViewModel.Name = user.UserName;
            userEditViewModel.SurName = user.SurName;
            userEditViewModel.Email = user.Email;
            
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            if(userEditViewModel.Password== userEditViewModel.ConfirmPassword)
            {
                var user = await _userManager.FindByIdAsync(User.Identity.Name);
                user.Name = userEditViewModel.UserName;
                user.SurName = userEditViewModel.SurName;
                user.Email = userEditViewModel.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
                await _userManager.UpdateAsync(user);

                return RedirectToAction("Index", "Login");
            }
            return View();
            
        }
        
    }
}
