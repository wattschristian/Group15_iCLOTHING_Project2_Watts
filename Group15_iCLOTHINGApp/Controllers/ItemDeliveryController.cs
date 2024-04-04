using Group15_iCLOTHINGApp.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Group15_iCLOTHINGApp.Controllers
{
    public class ItemDeliveryController : Controller
    {
        private Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();

        // GET: ItemDelivery
        public ActionResult Index()
        {
            return View(db.ItemDelivery.ToList());
        }

        // GET: ItemDelivery/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDelivery itemDelivery = db.ItemDelivery.Find(id);
            if (itemDelivery == null)
            {
                return HttpNotFound();
            }
            return View(itemDelivery);
        }

        // GET: ItemDelivery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemDelivery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stickerID,stickerDate")] ItemDelivery itemDelivery)
        {
            if (ModelState.IsValid)
            {
                db.ItemDelivery.Add(itemDelivery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemDelivery);
        }

        // GET: ItemDelivery/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDelivery itemDelivery = db.ItemDelivery.Find(id);
            if (itemDelivery == null)
            {
                return HttpNotFound();
            }
            return View(itemDelivery);
        }

        // POST: ItemDelivery/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stickerID,stickerDate")] ItemDelivery itemDelivery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemDelivery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemDelivery);
        }

        // GET: ItemDelivery/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDelivery itemDelivery = db.ItemDelivery.Find(id);
            if (itemDelivery == null)
            {
                return HttpNotFound();
            }
            return View(itemDelivery);
        }

        // POST: ItemDelivery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ItemDelivery itemDelivery = db.ItemDelivery.Find(id);
            db.ItemDelivery.Remove(itemDelivery);
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
