using Group15_iCLOTHINGApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Group15_iCLOTHINGApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();

        // GET: ShoppingCart
        public ActionResult Index(bool add_removeFlag = false, string productPrice = "", string productID = "", string productName = "", int quantity = 0)
        {
            bool success = false;
            if (Session["UserID"] == null)
            {
                return RedirectToAction("UserLogin", "UserLogin");
            }
            else
            {
                if (!productPrice.Equals("") && !productID.Equals("") && !productName.Equals("") && quantity != 0)
                {
                    if (Session["UserID"] == null)
                        return RedirectToAction("UserLogin", "UserLogin");
                    Random rnd = new Random();
                    string userID = Session["UserID"].ToString();
                    List<OrderStatus> orders = db.OrderStatus.Where(o => o.customerID.Equals(userID)).ToList();
                    OrderStatus order = null;
                    if (orders.Count == 0)
                    {
                        order = new OrderStatus();
                        order.statusID = rnd.Next(1000, 9999).ToString();
                        order.orderStatus1 = "inProgress";
                        order.statusDate = DateTime.Now;
                        order.customerID = Session["UserID"].ToString();
                        db.OrderStatus.Add(order);
                    }
                    else
                    {
                        order = orders.ElementAt(0);
                    }
                    Product product = new Product();
                    product.productPrice = decimal.Parse(productPrice);
                    product.productID = productID;
                    product.productName = productName;
                    product.productQty = quantity;
                    if (add_removeFlag)
                        success = AddItemToCart(product, order);
                    else if (!add_removeFlag)
                        success = RemoveItemFromCart(product);
                    db.SaveChanges();
                }
                if (success && add_removeFlag)
                {
                    return RedirectToAction("Index", "UserQuery");
                }
                else if (success && !add_removeFlag)
                {
                    return RedirectToAction("Index", "ShoppingCart");
                }
            }
            return View(db.ShoppingCart.ToList());
        }

        public bool AddItemToCart(Product product, OrderStatus order)
        {
            ShoppingCart cart = db.ShoppingCart.Where(p => p.productID == product.productID).FirstOrDefault();
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            cart.cartProductName = product.productName;
            cart.statusID = order.statusID.ToString();
            cart.cartProductPrice = product.productPrice;
            cart.cartProductQty += product.productQty;
            cart.customerID = Session["UserID"].ToString();
            cart.productID = product.productID;
            db.ShoppingCart.AddOrUpdate(cart);
            return true;
        }

        public bool RemoveItemFromCart(Product product)
        {
            bool success = false;
            ShoppingCart userCart = db.ShoppingCart.Where(p => p.productID == product.productID).First();
            if (userCart != null)
            {
                if (userCart.productID == product.productID)
                {
                    if (product.productQty < userCart.cartProductQty)
                    {
                        userCart.cartProductQty -= product.productQty;
                        db.ShoppingCart.Attach(userCart);
                        db.Entry(userCart).Property(p => p.cartProductQty).IsModified = true;
                    }
                    else
                    {
                        db.ShoppingCart.Remove(userCart);
                    }
                    success = true;
                }
            }
            else
                return false;
            return success;
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
