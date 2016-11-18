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
    [Authorize(Roles ="Food Donor")]

    public class ProviderPostsController : Controller
    {
        private GotFoodContext db = new GotFoodContext();

        // GET: ProviderPosts
        public ActionResult Index()
        {
            var providerPosts = db.ProviderPosts.Include(p => p.Provider);
            return View(providerPosts.ToList());
        }

        // GET: ProviderPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderPost providerPost = db.ProviderPosts.Find(id);
            if (providerPost == null)
            {
                return HttpNotFound();
            }
            return View(providerPost);
        }

        // GET: ProviderPosts/Create
        public ActionResult Create()
        {
            ViewBag.ProviderID = new SelectList(db.Providers, "ProviderID", "OrgName");
            return View();
        }

        // POST: ProviderPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProviderPostID,ProviderID,TimeStamp,FoodType,PeopleFed,PotentialAllergens,ExpirationDate,SpecialTransport,Comments")] ProviderPost providerPost)
        {
            if (ModelState.IsValid)
            {
                db.ProviderPosts.Add(providerPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProviderID = new SelectList(db.Providers, "ProviderID", "OrgName", providerPost.ProviderID);
            return View(providerPost);
        }

        // GET: ProviderPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderPost providerPost = db.ProviderPosts.Find(id);
            if (providerPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProviderID = new SelectList(db.Providers, "ProviderID", "OrgName", providerPost.ProviderID);
            return View(providerPost);
        }

        // POST: ProviderPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProviderPostID,ProviderID,TimeStamp,FoodType,PeopleFed,PotentialAllergens,ExpirationDate,SpecialTransport,Comments")] ProviderPost providerPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(providerPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProviderID = new SelectList(db.Providers, "ProviderID", "OrgName", providerPost.ProviderID);
            return View(providerPost);
        }

        // GET: ProviderPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderPost providerPost = db.ProviderPosts.Find(id);
            if (providerPost == null)
            {
                return HttpNotFound();
            }
            return View(providerPost);
        }

        // POST: ProviderPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProviderPost providerPost = db.ProviderPosts.Find(id);
            db.ProviderPosts.Remove(providerPost);
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
