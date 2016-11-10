using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GotFood.Models;

namespace GotFood.Controllers
{
    public class ProviderTypesController : Controller
    {
        private GotFoodContext db = new GotFoodContext();

        // GET: ProviderTypes
        public ActionResult Index()
        {
            return View(db.ProviderTypes.ToList());
        }

        // GET: ProviderTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderType providerType = db.ProviderTypes.Find(id);
            if (providerType == null)
            {
                return HttpNotFound();
            }
            return View(providerType);
        }

        // GET: ProviderTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProviderTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type")] ProviderType providerType)
        {
            if (ModelState.IsValid)
            {
                db.ProviderTypes.Add(providerType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(providerType);
        }

        // GET: ProviderTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderType providerType = db.ProviderTypes.Find(id);
            if (providerType == null)
            {
                return HttpNotFound();
            }
            return View(providerType);
        }

        // POST: ProviderTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type")] ProviderType providerType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(providerType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(providerType);
        }

        // GET: ProviderTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderType providerType = db.ProviderTypes.Find(id);
            if (providerType == null)
            {
                return HttpNotFound();
            }
            return View(providerType);
        }

        // POST: ProviderTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProviderType providerType = db.ProviderTypes.Find(id);
            db.ProviderTypes.Remove(providerType);
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
