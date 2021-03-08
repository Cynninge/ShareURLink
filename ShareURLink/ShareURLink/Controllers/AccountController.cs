using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShareURLink.Models;
using ShareURLink.Services.Interfaces;
using ShareURLink.ViewModels;
using System.Threading.Tasks;

namespace ShareURLink.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> userManager;
        private readonly SignInManager<UserModel> signInManager;
        private readonly ILinkService linkService;
        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, ILinkService linkService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.linkService = linkService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Profile(string name)
        {
            var userLinks = linkService.GetLinksByUserName(name);
            var user = await userManager.FindByNameAsync(name);
            var linkUserViewModel = new LinkUserViewModel()
            {
                Links = userLinks,
                User = user
            };
            if(await userManager.GetUserAsync(this.User) != linkUserViewModel.User)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(linkUserViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {

            if (ModelState.IsValid)
            {                
                var result = await signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);

                if (result.Succeeded)
                {                    
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Login failed");
            }
            return View(login);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {

            if(ModelState.IsValid)
            {
                var user = new UserModel { UserName = registerModel.Email, Email = registerModel.Email };
                var result = await userManager.CreateAsync(user, registerModel.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return View("Success");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(registerModel);
        }        
    }
}