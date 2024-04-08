using Group15_iCLOTHINGApp.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Group15_iCLOTHINGApp.Controllers
{
    public class ProductController : Controller
    {
        private Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();

        // GET: Product
        public ActionResult Index()
        {
            ViewBag.Cart = db.ShoppingCart.ToList();
            if (TempData["products"] != null)
            {
                List<Product> products = (List<Product>)TempData["products"];
                TempData["products"] = null;
                return View(products);
            }
            return View(db.Product.ToList());
        }

        public ActionResult Filter(string brandID = "", string categoryID = "", string departmentID = "", string searchString = "EMPTY")
        {
            List<Product> products = db.Product.ToList();
            List<Product> filteredProducts = new List<Product>();
            if (!brandID.Equals(""))
            {
                filteredProducts = db.Product.Where(p => p.brandID.Equals(brandID)).Select(p => p).ToList();
            }
            else if(!categoryID.Equals(""))
            {
                filteredProducts = db.Product.Where(p => p.categoryID.Equals(categoryID)).Select(p => p).ToList();
            }
            else if (!departmentID.Equals(""))
            {
                filteredProducts = db.Product.Where(p => p.departmentID.Equals(departmentID)).Select(p => p).ToList();
            }
            else if (!searchString.Equals("EMPTY"))
            {
                filteredProducts = db.Product.Where(p => p.productName.Contains(searchString)
                || p.productDescription.Contains(searchString)).Select(p => p).ToList();
                if(!searchString.Equals(""))
                    Session["products"] = filteredProducts;
                return RedirectToAction("Index", "UserQuery");
            }
            TempData["products"] = filteredProducts;
            return RedirectToAction("Index");
        }

        // GET: Product/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.BrandList = ToSelectList("Brand");
            ViewBag.CategoryList = ToSelectList("Category");
            ViewBag.DepartmentList = ToSelectList("Department");
            return View();
        }

        public SelectList ToSelectList(string type)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            switch (type)
            {
                case "Brand":
                    foreach (Brand b in db.Brand)
                    {
                        list.Add(new SelectListItem()
                        {
                            Text = b.brandName,
                            Value = b.brandID
                        });
                    }
                    break;
                case "Category":
                    foreach (Category c in db.Category)
                    {
                        list.Add(new SelectListItem()
                        {
                            Text = c.categoryName,
                            Value = c.categoryID
                        });
                    }
                    break;
                case "Department":
                    foreach (Department d in db.Department)
                    {
                        list.Add(new SelectListItem()
                        {
                            Text = d.departmentName,
                            Value = d.departmentID
                        });
                    }
                    break;
            }
            return new SelectList(list, "Value", "Text");
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productName,productDescription,productPrice,productQty,brandID,categoryID,departmentID")] Product product)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                product.productID = rnd.Next(1000, 9999).ToString();
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("MaintainCatalog", "Administrator");
            }

            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productID,productName,productDescription,productPrice,productQty")] Product product)
        {
            if (ModelState.IsValid)
            {
                Product product2 = db.Product.Find(product.productID);
                product2.productName = product.productName;
                product2.productDescription = product.productDescription;
                product2.productPrice = product.productPrice;
                product2.productQty = product.productQty;
                db.Entry(product2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MaintainCatalog", "Administrator");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("MaintainCatalog", "Administrator");
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
