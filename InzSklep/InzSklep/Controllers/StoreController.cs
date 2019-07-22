﻿using InzSklep.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InzSklep.Controllers
{
    public class StoreController : Controller
    {
        StoreContext db = new StoreContext();

        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string categoryname)
        {
            var category = db.Categories.Include("Products").Where(g => g.Name.ToUpper() == categoryname.ToUpper()).Single();
            var products = category.Products.ToList();
            return View(products);
        }

        [OutputCache(Duration = 80000)]
        [ChildActionOnly]
        public ActionResult CategoriesMenu()
        {
            var categories = db.Categories.ToList();
            return PartialView("_CategoriesMenu", categories);
        }

        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }
        public ActionResult Hot(int id)
        {
            var hotOffer = db.HotOffers.Find(id);
            return View(hotOffer);
        }
    }
}