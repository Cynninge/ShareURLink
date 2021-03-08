using Microsoft.AspNetCore.Mvc;
using ShareURLink.Services.Interfaces;
using System.Threading.Tasks;
using X.PagedList;

namespace ShareURLink.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILinkService _linkService;
        public HomeController(ILinkService linkService)
        {
            _linkService = linkService;
        }
        public async Task<IActionResult> Index(int? page)
        {
            var LinksList = _linkService.GetLinks();
            var pageNumber = page ?? 1;
            var perPage = 25;
            var onePageOfEvents = await LinksList.ToPagedListAsync(pageNumber, perPage);
            return View(onePageOfEvents);
        }
    }
}