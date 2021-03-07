using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShareURLink.Models;
using ShareURLink.Services.Interfaces;
using ShareURLink.ViewModels;
using System.Threading.Tasks;

namespace ShareURLink.Controllers
{
    public class LinkController : Controller
    {
        private readonly ILinkService linkService;
        private readonly UserManager<UserModel> userManager;
        public LinkController(ILinkService linkService, UserManager<UserModel> userManager)
        {
            this.linkService = linkService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {            
            return View();
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
               
            return Redirect("~/Home/Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var linkModel = linkService.GetLink(id);
            return View(linkModel);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {            
            linkService.RemoveLink(id);
            return Redirect("~/Home/Index");
        }

        //[HttpGet]
        //public IActionResult LikeIt(int id)
        //{
        //    return RedirectToAction("LikeItPost", "Link", id);
        //}

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