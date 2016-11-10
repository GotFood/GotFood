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
    public class ProviderTransportationsController : Controller
    {
        private GotFoodContext db = new GotFoodContext();

        // GET: ProviderTransportations
        public ActionResult Index()
        {
            return View(db.ProviderTransportations.ToList());
        }

        // GET: ProviderTransportations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderTransportation providerTransportation = db.ProviderTransportations.Find(id);
            if (providerTransportation == null)
            {
                return HttpNotFound();
            }
            return View(providerTransportation);
        }

        // GET: ProviderTransportations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProviderTransportations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Trans")] ProviderTransportation providerTransportation)
        {
            if (ModelState.IsValid)
            {
                db.ProviderTransportations.Add(providerTransportation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(providerTransportation);
        }

        // GET: ProviderTransportations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderTransportation providerTransportation = db.ProviderTransportations.Find(id);
            if (providerTransportation == null)
            {
                return HttpNotFound();
            }
            return View(providerTransportation);
        }

        // POST: ProviderTransportations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Trans")] ProviderTransportation providerTransportation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(providerTransportation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(providerTransportation);
        }

        // GET: ProviderTransportations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderTransportation providerTransportation = db.ProviderTransportations.Find(id);
            if (providerTransportation == null)
            {
                return HttpNotFound();
            }
            return View(providerTransportation);
        }

        // POST: ProviderTransportations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProviderTransportation providerTransportation = db.ProviderTransportations.Find(id);
            db.ProviderTransportations.Remove(providerTransportation);
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
