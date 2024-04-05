using Group15_iCLOTHINGApp.Models;
using System.Web.Mvc;

namespace Group15_iCLOTHINGApp.Controllers
{
    public class HomeController : Controller
    {
        Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();
        public ActionResult Index(bool logoutflag = false)
        {
            if (logoutflag)
            {
                Session["UserID"] = null;
                Session["AdminID"] = null;
            }
            return View(db.Product);
        }

        public ActionResult UserIndex()
        {
            return View(db.Product);
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