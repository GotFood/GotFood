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
    public class TransportPostsController : Controller
    {
        private GotFoodContext db = new GotFoodContext();

        // GET: TransportPosts
        public ActionResult Index()
        {
            var transportPosts = db.TransportPosts.Include(t => t.Transport);
            return View(transportPosts.ToList());
        }

        // GET: TransportPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportPost transportPost = db.TransportPosts.Find(id);
            if (transportPost == null)
            {
                return HttpNotFound();
            }
            return View(transportPost);
        }

        // GET: TransportPosts/Create
        public ActionResult Create()
        {
            ViewBag.TransportID = new SelectList(db.Transports, "TransportID", "OrganizationName");
            return View();
        }

        // POST: TransportPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransportPostID,TransportID,TimeStamp,Message,DateAvailable,Comments")] TransportPost transportPost)
        {
            if (ModelState.IsValid)
            {
                db.TransportPosts.Add(transportPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TransportID = new SelectList(db.Transports, "TransportID", "OrganizationName", transportPost.TransportID);
            return View(transportPost);
        }

        // GET: TransportPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportPost transportPost = db.TransportPosts.Find(id);
            if (transportPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransportID = new SelectList(db.Transports, "TransportID", "OrganizationName", transportPost.TransportID);
            return View(transportPost);
        }

        // POST: TransportPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransportPostID,TransportID,TimeStamp,Message,DateAvailable,Comments")] TransportPost transportPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TransportID = new SelectList(db.Transports, "TransportID", "OrganizationName", transportPost.TransportID);
            return View(transportPost);
        }

        // GET: TransportPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportPost transportPost = db.TransportPosts.Find(id);
            if (transportPost == null)
            {
                return HttpNotFound();
            }
            return View(transportPost);
        }

        // POST: TransportPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransportPost transportPost = db.TransportPosts.Find(id);
            db.TransportPosts.Remove(transportPost);
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
