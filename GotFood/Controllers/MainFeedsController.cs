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
    public class MainFeedsController : Controller
    {
        private GotFoodContext db = new GotFoodContext();

        // GET: MainFeeds
        public ActionResult Index()
        {
            var mainFeeds = db.MainFeeds.Include(m => m.CharityPost).Include(m => m.ProviderPost).Include(m => m.TransportPost);
            return View(mainFeeds.ToList());
        }

        // GET: MainFeeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainFeed mainFeed = db.MainFeeds.Find(id);
            if (mainFeed == null)
            {
                return HttpNotFound();
            }
            return View(mainFeed);
        }

        // GET: MainFeeds/Create
        public ActionResult Create()
        {
            ViewBag.CharityPostID = new SelectList(db.CharityPosts, "CharityPostID", "FoodRequested");
            ViewBag.ProviderPostID = new SelectList(db.ProviderPosts, "ProviderPostID", "FoodType");
            ViewBag.TransportPostID = new SelectList(db.TransportPosts, "TransportPostID", "Message");
            return View();
        }

        // POST: MainFeeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MainFeedID,ProviderPostID,CharityPostID,TransportPostID")] MainFeed mainFeed)
        {
            if (ModelState.IsValid)
            {
                db.MainFeeds.Add(mainFeed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CharityPostID = new SelectList(db.CharityPosts, "CharityPostID", "FoodRequested", mainFeed.CharityPostID);
            ViewBag.ProviderPostID = new SelectList(db.ProviderPosts, "ProviderPostID", "FoodType", mainFeed.ProviderPostID);
            ViewBag.TransportPostID = new SelectList(db.TransportPosts, "TransportPostID", "Message", mainFeed.TransportPostID);
            return View(mainFeed);
        }

        // GET: MainFeeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainFeed mainFeed = db.MainFeeds.Find(id);
            if (mainFeed == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharityPostID = new SelectList(db.CharityPosts, "CharityPostID", "FoodRequested", mainFeed.CharityPostID);
            ViewBag.ProviderPostID = new SelectList(db.ProviderPosts, "ProviderPostID", "FoodType", mainFeed.ProviderPostID);
            ViewBag.TransportPostID = new SelectList(db.TransportPosts, "TransportPostID", "Message", mainFeed.TransportPostID);
            return View(mainFeed);
        }

        // POST: MainFeeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MainFeedID,ProviderPostID,CharityPostID,TransportPostID")] MainFeed mainFeed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainFeed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CharityPostID = new SelectList(db.CharityPosts, "CharityPostID", "FoodRequested", mainFeed.CharityPostID);
            ViewBag.ProviderPostID = new SelectList(db.ProviderPosts, "ProviderPostID", "FoodType", mainFeed.ProviderPostID);
            ViewBag.TransportPostID = new SelectList(db.TransportPosts, "TransportPostID", "Message", mainFeed.TransportPostID);
            return View(mainFeed);
        }

        // GET: MainFeeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainFeed mainFeed = db.MainFeeds.Find(id);
            if (mainFeed == null)
            {
                return HttpNotFound();
            }
            return View(mainFeed);
        }

        // POST: MainFeeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MainFeed mainFeed = db.MainFeeds.Find(id);
            db.MainFeeds.Remove(mainFeed);
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
