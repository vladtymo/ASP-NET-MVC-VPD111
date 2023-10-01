using AspNet_MVC_VPD111.Models;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNet_MVC_VPD111.Controllers
{
    public class HomeController : Controller
    {
        private readonly Shop111DbContext ctx;

        public HomeController(Shop111DbContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            // get data from DB, validations and etc...
            // ... code ...
            return this.View(ctx.Products.ToList()); // ~/Views/Home/Index.cshtml
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
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