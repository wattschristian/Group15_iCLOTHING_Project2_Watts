using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Group15_iCLOTHINGApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserIndex() 
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to iCLOTHING! We are dedicated to bringing you quality products at an affordable price.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Developers: Alex Kochman,\tParker Dierkens,\tChristian Watts";

            return View();
        }
    }
}