using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task.Models;

namespace Task.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: ProductCategories
        public ActionResult Index()
        {
            return View(db.ProductCategories.ToList());
        }

        // GET: ProductCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategories productCategories = db.ProductCategories.Find(id);
            if (productCategories == null)
            {
                return HttpNotFound();
            }
            return View(productCategories);
        }

        // GET: ProductCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ProductCategories productCategories)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories.Add(productCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productCategories);
        }

        // GET: ProductCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategories productCategories = db.ProductCategories.Find(id);
            if (productCategories == null)
            {
                return HttpNotFound();
            }
            return View(productCategories);
        }

        // POST: ProductCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ProductCategories productCategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productCategories);
        }

        // GET: ProductCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategories productCategories = db.ProductCategories.Find(id);
            if (productCategories == null)
            {
                return HttpNotFound();
            }
            return View(productCategories);
        }

        // POST: ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductCategories productCategories = db.ProductCategories.Find(id);
            db.ProductCategories.Remove(productCategories);
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
