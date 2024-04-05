using Group15_iCLOTHINGApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Group15_iCLOTHINGApp.Controllers
{
    public class AdministratorController : Controller
    {
        private Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();

        // GET: Administrators
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MaintainCatalog()
        {
            ViewBag.Products = db.Product.ToList(); ;
            ViewBag.Categories = db.Category.ToList(); ;
            ViewBag.Departments = db.Department.ToList(); ;
            return View();
        }

        public ActionResult ManageOrders()
        { 
            return View(); 
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
