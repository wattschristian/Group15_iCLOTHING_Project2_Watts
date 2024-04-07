using Group15_iCLOTHINGApp.Models;
using System;
using System.Web.Mvc;

namespace Group15_iCLOTHINGApp.Controllers
{
    public class HomeController : Controller
    {
        Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();
        public ActionResult Index()
        {
            return View(db.Product);
        }

        public ActionResult Logout() 
        {
            Session["UserID"] = null;
            Session["AdminID"] = null;
            foreach (var item in db.ShoppingCart)
            {
                db.ShoppingCart.Remove(item);
            }
            db.SaveChanges();
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.WelcomeMessage = "Welcome to iCLOTHING! We are dedicated to bringing you quality products at an affordable price.";
            ViewBag.Message = "The iCLOTHING website was started in 2024 with a vision to bring all your favorite clothing items to the online market. Our founder, "
                + "Dr. Abdelnasser Ouda, started iCLOTHING as a local favorite fashion store and quickly realized the potential for growth in the realm of e-commerce.";
            ViewBag.ThankYou = "Thank you for choosing iCLOTHING as your source of fashion, feel free to get in contact with us using our Contact page above!";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Developers: Alex Kochman,\tParker Dierkens,\tChristian Watts";

            return View();
        }
    }
}