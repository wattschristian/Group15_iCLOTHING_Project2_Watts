using Group15_iCLOTHINGApp.Models;
using System;
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

        public ActionResult AddItemToCart(Product product, int quantity=1)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("UserLogin", "UserLogin");
            Random rnd = new Random();
            ShoppingCart cart = new ShoppingCart();
            cart.cartID = rnd.Next(1000, 9999);
            cart.cartProductPrice = product.productPrice;
            cart.cartProductQty = quantity;
            cart.customerID = Session["UserID"].ToString();
            cart.productID = product.productID;
            db.ShoppingCart.Add(cart);
            db.SaveChanges();
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
