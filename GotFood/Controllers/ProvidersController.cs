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
    public class ProvidersController : Controller
    {
        private GotFoodContext db = new GotFoodContext();

        // GET: Providers
        public ActionResult Index()
        {
            var providers = db.Providers.Include(p => p.ProviderTransportation).Include(p => p.ProviderType);
            return View(providers.ToList());
        }

        // GET: Providers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // GET: Providers/Create
        public ActionResult Create()
        {
            ViewBag.TranspoID = new SelectList(db.ProviderTransportations, "ID", "Trans");
            ViewBag.TypeID = new SelectList(db.ProviderTypes, "ID", "Type");
            return View();
        }

        // POST: Providers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProviderID,OrgName,ContactName,ContactEmail,ContactPhone,StreetNumber,StreetName,City,State,ZipCode,Website,Foods,TypeID,TranspoID")] Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Providers.Add(provider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TranspoID = new SelectList(db.ProviderTransportations, "ID", "Trans", provider.TranspoID);
            ViewBag.TypeID = new SelectList(db.ProviderTypes, "ID", "Type", provider.TypeID);
            return View(provider);
        }

        // GET: Providers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            ViewBag.TranspoID = new SelectList(db.ProviderTransportations, "ID", "Trans", provider.TranspoID);
            ViewBag.TypeID = new SelectList(db.ProviderTypes, "ID", "Type", provider.TypeID);
            return View(provider);
        }

        // POST: Providers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProviderID,OrgName,ContactName,ContactEmail,ContactPhone,StreetNumber,StreetName,City,State,ZipCode,Website,Foods,TypeID,TranspoID")] Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TranspoID = new SelectList(db.ProviderTransportations, "ID", "Trans", provider.TranspoID);
            ViewBag.TypeID = new SelectList(db.ProviderTypes, "ID", "Type", provider.TypeID);
            return View(provider);
        }

        // GET: Providers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // POST: Providers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provider provider = db.Providers.Find(id);
            db.Providers.Remove(provider);
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
