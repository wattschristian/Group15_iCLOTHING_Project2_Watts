using Group15_iCLOTHINGApp.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Group15_iCLOTHINGApp.Controllers
{
    public class UserQueryController : Controller
    {
        private Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();

        public ActionResult Index()
        {
            if (Session["products"] != null)
            {
                List<Product> products = (List<Product>)Session["products"];
                Session["products"] = null;
                return View(products);
            }
            return View(db.Product.ToList());
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
