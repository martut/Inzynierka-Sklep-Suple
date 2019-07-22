using InzSklep.DAL;
using InzSklep.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InzSklep.Controllers
{
    public class HomeController : Controller
    {
        StoreContext db = new StoreContext();
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();

            var bestseller = db.Products.Where(a => !a.IsHidden && a.IsBestSeller).OrderBy(a => Guid.NewGuid()).Take(4).ToList();

            var newest = db.Products.Where(a => !a.IsHidden).OrderByDescending(a => a.AddedDate).Take(4).ToList();

            var offerSlider = db.HotOffers.ToList();

            var vm = new HomeViewModel()
            {
                BestSeller = bestseller,
                Newest = newest,
                OfferSlider = offerSlider,
                Categories = categories
            };

            return View(vm);
        }

        [ChildActionOnly]
        public ActionResult NavbarMenu()
        {
            var categories = db.Categories.ToList();

            var producers = db.Producers.ToList();

            var vm = new HomeViewModel()
            {
                Categories = categories,
                Producers = producers
            };

            return PartialView("_NavbarMenu", vm);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Complaint()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Faq()
        {
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }
        public ActionResult Regulations()
        {
            return View();
        }
        public ActionResult Safety()
        {
            return View();
        }
        public ActionResult Shipment()
        {
            return View();
        }

    }
}