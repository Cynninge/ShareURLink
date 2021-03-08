using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PagedList.Mvc;
using PagedList;
using ShareURLink.Services.Interfaces;

namespace ShareURLink.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILinkService _linkService;
        public HomeController(ILinkService linkService)
        {
            _linkService = linkService;
        }
        public IActionResult Index(int? page)
        {
            var LinksList = _linkService.GetLinks();
            return View(LinksList.ToPagedList(page ?? 1,3));
        }
    }
}