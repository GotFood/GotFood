
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
    
    public class ScoreBoardController : Controller
    {

        private GotFoodContext db = new GotFoodContext();

        // GET: ScoreBoard
        public ActionResult Index()
        {
            ViewBag.Level = "1";
            var providers = db.Providers.Include(p => p.ProviderTransportation).Include(p => p.ProviderType);

            //Provider provider = db.Providers.Find(id);
            return View(providers.ToList());

            
            
        }

        public ActionResult Donate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Provider provider = db.Providers.Find(id);

            if(provider == null)
            {
                return HttpNotFound();
            }

           // int donations = provider.NumOfDonation;
            //int newNum = donations++;
            //newNum = provider.NumOfDonation;
            provider.NumOfDonation++;
            //db.Entry(provider).State = EntityState.Modified;


            if (ModelState.IsValid)
            {
                db.Entry(provider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult NumOfDonation(int? id)
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


            if (provider.NumOfDonation >= 0 && provider.NumOfDonation <= 5)
            {
                ViewBag.Level = "1";
            }
            else if (provider.NumOfDonation > 5 && provider.NumOfDonation<=12)
            {
                ViewBag.Level = "2";
            }
            db.SaveChanges();

            return RedirectToAction("Index");
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
            if (provider.NumOfDonation >= 0 && provider.NumOfDonation <= 5)
            {
                ViewBag.Level = "1";
            }
            else if (provider.NumOfDonation > 5 && provider.NumOfDonation <= 12)
            {
                ViewBag.Level = "2";
            }
            return View(provider);
        }
    }

};