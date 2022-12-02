using LiveApp.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LiveApp.Controllers
{
    [Route("[action]")]
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }
        [Route("~/")]
        public ViewResult Index()
        {
            Title = "Home";
            return View();
        }

        [CustomActionFilter]
        public ViewResult AboutUs()
        {
            Title = "About Us";
            return View();
        }

        [CustomActionFilter]
        public ViewResult ContactUs()
        {
            Title = "Contact Us";
            return View();
        }
    }
}
