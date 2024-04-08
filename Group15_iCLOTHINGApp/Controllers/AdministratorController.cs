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
            ViewBag.Brands = db.Brand.ToList(); ;
            return View();
        }

        public ActionResult ManageOrders()
        {
            // Retrieve all orders
            List<OrderStatus> allOrders = db.OrderStatus.ToList();

            // Pass the list of orders to the view
            return View(allOrders);
        }

        public ActionResult ApproveOrder(string statusID)
        {
            // Retrieve the order status from the database
            OrderStatus order = db.OrderStatus.FirstOrDefault(o => o.statusID == statusID);
            if (order != null)
            {
                // Update the order status to "shipped"
                order.orderStatus1 = "Shipped";
                order.adminUpdated = Session["AdminID"].ToString();
                db.SaveChanges();
            }
            return RedirectToAction("ManageOrders");
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
