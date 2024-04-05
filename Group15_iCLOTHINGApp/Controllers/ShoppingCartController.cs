using Group15_iCLOTHINGApp.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Group15_iCLOTHINGApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("UserLogin", "UserLogin");
            return View(db.ShoppingCart.ToList());
        }

        // GET: ShoppingCart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCart shoppingCart = db.ShoppingCart.Find(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart);
        }

        // GET: ShoppingCart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cartID,cartProductPrice,cartProductQty")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingCart.Add(shoppingCart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingCart);
        }

        // GET: ShoppingCart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCart shoppingCart = db.ShoppingCart.Find(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart);
        }

        // POST: ShoppingCart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cartID,cartProductPrice,cartProductQty")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingCart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingCart);
        }

        // GET: ShoppingCart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCart shoppingCart = db.ShoppingCart.Find(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart);
        }

        // POST: ShoppingCart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingCart shoppingCart = db.ShoppingCart.Find(id);
            db.ShoppingCart.Remove(shoppingCart);
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
