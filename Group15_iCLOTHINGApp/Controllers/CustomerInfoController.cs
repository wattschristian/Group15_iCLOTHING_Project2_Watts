using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Group15_iCLOTHINGApp.Models;

namespace Group15_iCLOTHINGApp.Controllers
{
    public class CustomerInfoController : Controller
    {
        private Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();

        // GET: CustomerInfo
        public ActionResult Index(CustomerInfo customer=null)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("UserLogin", "UserLogin");
            CustomerInfo c = db.CustomerInfo.Find(Session["UserID"].ToString());
            return View(c);
        }

        // GET: CustomerInfo/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInfo customerInfo = db.CustomerInfo.Find(id);
            if (customerInfo == null)
            {
                return HttpNotFound();
            }
            return View(customerInfo);
        }

        // GET: CustomerInfo/Create
        public ActionResult Create()
        {
            ViewBag.customerID = new SelectList(db.UserPassword, "userID", "userAccountName");
            return View();
        }

        // POST: CustomerInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerID,customerName,customerShippingAddress,customerBillingAddress,customerDOB,customerGender,userEncryptedPassword")] CustomerInfo customerInfo)
        {
            if (ModelState.IsValid)
            {
                db.CustomerInfo.Add(customerInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerID = new SelectList(db.UserPassword, "userID", "userAccountName", customerInfo.customerID);
            return View(customerInfo);
        }

        // GET: CustomerInfo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInfo customerInfo = db.CustomerInfo.Find(id);
            if (customerInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerID = new SelectList(db.UserPassword, "userID", "userAccountName", customerInfo.customerID);
            return View(customerInfo);
        }

        // POST: CustomerInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerID,customerName,customerShippingAddress,customerBillingAddress,customerDOB,customerGender,userEncryptedPassword")] CustomerInfo customerInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerID = new SelectList(db.UserPassword, "userID", "userAccountName", customerInfo.customerID);
            return View(customerInfo);
        }

        // GET: CustomerInfo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInfo customerInfo = db.CustomerInfo.Find(id);
            if (customerInfo == null)
            {
                return HttpNotFound();
            }
            return View(customerInfo);
        }

        // POST: CustomerInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CustomerInfo customerInfo = db.CustomerInfo.Find(id);
            db.CustomerInfo.Remove(customerInfo);
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
