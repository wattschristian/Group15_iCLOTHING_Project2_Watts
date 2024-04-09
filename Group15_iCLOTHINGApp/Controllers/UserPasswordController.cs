using Group15_iCLOTHINGApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Group15_iCLOTHINGApp.Controllers
{
    public class UserPasswordController : Controller
    {
        private Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();

        // GET: UserPassword/Create
        public ActionResult Create(string eMessage="")
        {
            ViewBag.ErrorMessage = eMessage;
            return View();
        }

        // POST: UserPassword/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userAccountName,userEncryptedPassword")] UserPassword userPassword)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                List<UserPassword> users = db.UserPassword.ToList();
                userPassword.userID = rnd.Next(1000, 9999).ToString();
                userPassword.passwordExpiryTime = 0;
                userPassword.userAccountExpiryDate = DateTime.Now.AddYears(1);
                foreach(var user in users)
                {
                    if(user.userAccountName == userPassword.userAccountName)
                    {
                        return RedirectToAction("Create", new { eMessage = "User exists, please login or create new account" });
                    }
                }
                db.UserPassword.Add(userPassword);
                CustomerInfo customer = new CustomerInfo();
                customer.customerID = userPassword.userID;
                customer.customerName = userPassword.userAccountName;
                customer.userEncryptedPassword = userPassword.userEncryptedPassword;
                db.CustomerInfo.Add(customer);
                db.SaveChanges();
                return RedirectToAction("UserLogin", "UserLogin");
            }
            return View(userPassword);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPassword up = db.UserPassword.Find(id);
            if (up == null)
            {
                return HttpNotFound();
            }
            return View(up);
        }

        // GET: Brands/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPassword up = db.UserPassword.Find(id);
            if (up == null)
            {
                return HttpNotFound();
            }
            return View(up);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,userAccountName,passwordExpiryTime,userAccountExpiryDate")] UserPassword user)
        {
            if (ModelState.IsValid)
            {
                UserPassword up = db.UserPassword.Find(user.userID);
                up.userAccountName = user.userAccountName;
                up.passwordExpiryTime = user.passwordExpiryTime;
                up.userAccountExpiryDate = user.userAccountExpiryDate;
                db.SaveChanges();
                return RedirectToAction("ManageUsers", "Administrator");
            }
            return RedirectToAction("ManageUsers", "Administrator");
        }

        // GET: Brands/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPassword up = db.UserPassword.Find(id);
            if (up == null)
            {
                return HttpNotFound();
            }
            return View(up);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserPassword up = db.UserPassword.Find(id);
            CustomerInfo c = db.CustomerInfo.Find(id);
            db.UserPassword.Remove(up);
            db.CustomerInfo.Remove(c);
            db.SaveChanges();
            return RedirectToAction("ManageUsers", "Administrator");
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
