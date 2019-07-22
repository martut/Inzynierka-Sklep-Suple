using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InzSklep.DAL;
using InzSklep.Models;

namespace InzSklep.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class HotOffersController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: HotOffers
        public ActionResult Index()
        {
            return View(db.HotOffers.ToList());
        }

        // GET: HotOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotOffer hotOffer = db.HotOffers.Find(id);
            if (hotOffer == null)
            {
                return HttpNotFound();
            }
            return View(hotOffer);
        }

        // GET: HotOffers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HotOfferId,OfferIMGFile,OfferLINQ,Title,Description")] HotOffer hotOffer)
        {
            if (ModelState.IsValid)
            {
                db.HotOffers.Add(hotOffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotOffer);
        }

        // GET: HotOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotOffer hotOffer = db.HotOffers.Find(id);
            if (hotOffer == null)
            {
                return HttpNotFound();
            }
            return View(hotOffer);
        }

        // POST: HotOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HotOfferId,OfferIMGFile,OfferLINQ,Title,Description")] HotOffer hotOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotOffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotOffer);
        }

        // GET: HotOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotOffer hotOffer = db.HotOffers.Find(id);
            if (hotOffer == null)
            {
                return HttpNotFound();
            }
            return View(hotOffer);
        }

        // POST: HotOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotOffer hotOffer = db.HotOffers.Find(id);
            db.HotOffers.Remove(hotOffer);
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
