using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IdentityPOC.Models;
using Microsoft.AspNetCore.Identity;
using IdentityPOC.Data.DALs;

namespace IdentityPOC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userMgr;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userMgr)
        {
            _logger = logger;
            _userMgr = userMgr;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public Task<ActionResult> Reporting()
        //{
        //    var user = _userMgr.Get
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
