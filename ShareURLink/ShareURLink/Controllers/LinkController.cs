using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShareURLink.Models;
using ShareURLink.Services.Interfaces;
using System.Threading.Tasks;

namespace ShareURLink.Controllers
{
    public class LinkController : Controller
    {
        private readonly ILinkService linkService;
        private readonly UserManager<UserModel> userManager;
        private readonly SignInManager<UserModel> signInManager;
        public LinkController(ILinkService linkService, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            this.linkService = linkService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            if(signInManager.IsSignedIn(User))
            {
                return View();
            }
            return View("Denied");

        }
        [HttpPost]
        public async Task<IActionResult> Create(LinkModel linkUser)
        {
            
            linkUser.User =  await userManager.GetUserAsync(this.User);
            if(ModelState.IsValid)
            {
                linkService.AddLink(linkUser);
            }
            else
            {
                return View(linkUser);
            }
            TempData["message"] = "Link added";
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (signInManager.IsSignedIn(User))
            {
                var linkModel = linkService.GetLink(id);
                if (await userManager.GetUserAsync(this.User) != linkModel.User)
                {
                    return View("Denied");
                }
                return View(linkModel);
            }
            return View("Denied");

        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {            
            linkService.RemoveLink(id);
            TempData["message"] = "Link removed";
            return Redirect("~/Home/Index");
        }

        [HttpPost]
        public async Task<IActionResult> LikeItPost(int id)
        {            
            var user = await userManager.GetUserAsync(this.User);
            string message;
            try
            {
                message = linkService.LikeIt(user, id);
            }
            catch (System.Exception)
            {
                throw;
            }
            TempData["message"] = message;
            return RedirectToAction("Index", "Home");
        }
    }
}