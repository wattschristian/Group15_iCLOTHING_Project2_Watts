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
    public class OrderStatusController : Controller
    {
        private Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();

        // GET: OrderStatus
        public ActionResult Index()
        {
            return View(db.OrderStatus.ToList());
        }

        public ActionResult Checkout()
        {
            if(db.ShoppingCart.ToList().Count > 0)
            {
                return View();
            }
            return RedirectToAction("Index", "ShoppingCart");
        }

        public ActionResult Summary(CustomerInfo customer)
        {
            string customerID = Session["UserID"].ToString();
            OrderStatus customerOrder = db.OrderStatus.Where(o => o.customerID.Equals(customerID)).First();
            List<ShoppingCart> cart = db.ShoppingCart.ToList();
            CustomerInfo customerInfo = db.CustomerInfo.Where(c => c.customerID.Equals(customerID)).First();
            customerInfo.customerShippingAddress = customer.customerShippingAddress;
            customerInfo.customerBillingAddress = customer.customerBillingAddress;
            customerInfo.customerDOB = customer.customerDOB;
            customerInfo.customerGender = customer.customerGender;
            db.CustomerInfo.AddOrUpdate(customerInfo);
            string estimatedShipping = DateTime.Now.AddDays(7).ToString();
            Tuple<string, List<ShoppingCart>, string, string> orderSummary = Tuple.Create(customerOrder.statusID, cart, customerInfo.customerName, estimatedShipping);
            foreach(var item in db.ShoppingCart)
            {
                db.ShoppingCart.Remove(item);
            }
            customerOrder.orderStatus1 = "Paid";
            db.SaveChanges();
            return View(orderSummary);
        }

        // GET: OrderStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderStatus orderStatus = db.OrderStatus.Find(id);
            if (orderStatus == null)
            {
                return HttpNotFound();
            }
            return View(orderStatus);
        }

        // GET: OrderStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "statusID,orderStatus1,statusDate")] OrderStatus orderStatus)
        {
            if (ModelState.IsValid)
            {
                db.OrderStatus.Add(orderStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderStatus);
        }

        // GET: OrderStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderStatus orderStatus = db.OrderStatus.Find(id);
            if (orderStatus == null)
            {
                return HttpNotFound();
            }
            return View(orderStatus);
        }

        // POST: OrderStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "statusID,orderStatus1,statusDate")] OrderStatus orderStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderStatus);
        }

        // GET: OrderStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderStatus orderStatus = db.OrderStatus.Find(id);
            if (orderStatus == null)
            {
                return HttpNotFound();
            }
            return View(orderStatus);
        }

        // POST: OrderStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderStatus orderStatus = db.OrderStatus.Find(id);
            db.OrderStatus.Remove(orderStatus);
            db.SaveChanges();
            return RedirectToAction("Index");
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
