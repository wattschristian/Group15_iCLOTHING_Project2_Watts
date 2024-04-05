using Group15_iCLOTHINGApp.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Group15_iCLOTHINGApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("UserLogin", "UserLogin");
            return View(db.ShoppingCart.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
