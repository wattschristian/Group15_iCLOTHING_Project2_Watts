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
    public class UserQueryController : Controller
    {
        private Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();

        // GET: UserQuery
        public ActionResult Index()
        {
            return View(db.UserQuery.ToList());
        }

        // GET: UserQuery/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserQuery userQuery = db.UserQuery.Find(id);
            if (userQuery == null)
            {
                return HttpNotFound();
            }
            return View(userQuery);
        }

        // GET: UserQuery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserQuery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "queryNo,queryDate,queryDescription")] UserQuery userQuery)
        {
            if (ModelState.IsValid)
            {
                db.UserQuery.Add(userQuery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userQuery);
        }

        // GET: UserQuery/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserQuery userQuery = db.UserQuery.Find(id);
            if (userQuery == null)
            {
                return HttpNotFound();
            }
            return View(userQuery);
        }

        // POST: UserQuery/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "queryNo,queryDate,queryDescription")] UserQuery userQuery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userQuery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userQuery);
        }

        // GET: UserQuery/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserQuery userQuery = db.UserQuery.Find(id);
            if (userQuery == null)
            {
                return HttpNotFound();
            }
            return View(userQuery);
        }

        // POST: UserQuery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserQuery userQuery = db.UserQuery.Find(id);
            db.UserQuery.Remove(userQuery);
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
