
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

            int donations = provider.NumOfDonation;
            donations += 1;

            db.SaveChanges();

            if(donations >= 0 && donations<= 5)
            {
                ViewBag.Level = 1;
            }
            return RedirectToAction("Index");
        }
    }
};