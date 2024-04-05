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

        public ActionResult Index(string productPrice="", string productID="", int quantity = 1)
        {
            if (Session["products"] != null)
            {
                List<Product> products = (List<Product>)Session["products"];
                Session["products"] = null;
                return View(products);
            }
            else if(!productPrice.Equals("") && !productID.Equals(""))
            {
                if (Session["UserID"] == null)
                    return RedirectToAction("UserLogin", "UserLogin");
                Random rnd = new Random();
                ShoppingCart cart = new ShoppingCart();
                cart.cartID = rnd.Next(1000, 9999);
                Session["CartID"] = cart.cartID;
                cart.statusID = rnd.Next(1000, 9999);
                cart.cartProductPrice = decimal.Parse(productPrice);
                cart.cartProductQty = quantity;
                cart.customerID = Session["UserID"].ToString();
                cart.productID = productID;
                db.ShoppingCart.Add(cart);
                db.SaveChanges();
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
