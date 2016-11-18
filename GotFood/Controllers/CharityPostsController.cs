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
    [Authorize(Roles ="Charity")]

    public class CharityPostsController : Controller
    {
        private GotFoodContext db = new GotFoodContext();

        // GET: CharityPosts
        public ActionResult Index()
        {
            var charityPosts = db.CharityPosts.Include(c => c.CharityProfile);
            return View(charityPosts.ToList());
        }

        // GET: CharityPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharityPost charityPost = db.CharityPosts.Find(id);
            if (charityPost == null)
            {
                return HttpNotFound();
            }
            return View(charityPost);
        }

        // GET: CharityPosts/Create
        public ActionResult Create()
        {
            ViewBag.CharityID = new SelectList(db.CharityProfiles, "CharityID", "CharityName");
            return View();
        }

        // POST: CharityPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CharityPostID,CharityID,TimeStamp,FoodRequested,WeightRequested,PeopleToFeed,DateRequested,Comments")] CharityPost charityPost)
        {
            if (ModelState.IsValid)
            {
                db.CharityPosts.Add(charityPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CharityID = new SelectList(db.CharityProfiles, "CharityID", "CharityName", charityPost.CharityID);
            return View(charityPost);
        }

        // GET: CharityPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharityPost charityPost = db.CharityPosts.Find(id);
            if (charityPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharityID = new SelectList(db.CharityProfiles, "CharityID", "CharityName", charityPost.CharityID);
            return View(charityPost);
        }

        // POST: CharityPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CharityPostID,CharityID,TimeStamp,FoodRequested,WeightRequested,PeopleToFeed,DateRequested,Comments")] CharityPost charityPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(charityPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CharityID = new SelectList(db.CharityProfiles, "CharityID", "CharityName", charityPost.CharityID);
            return View(charityPost);
        }

        // GET: CharityPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharityPost charityPost = db.CharityPosts.Find(id);
            if (charityPost == null)
            {
                return HttpNotFound();
            }
            return View(charityPost);
        }

        // POST: CharityPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CharityPost charityPost = db.CharityPosts.Find(id);
            db.CharityPosts.Remove(charityPost);
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
