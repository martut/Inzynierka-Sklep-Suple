using InzSklep.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InzSklep.Models;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Data.Entity;

namespace InzSklep.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        StoreContext db = new StoreContext();
        // GET: Profile
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var userID = User.Identity.GetUserId();

                UserData userdata = db.UserDatas.Find(userID);

                return View(userdata);


            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Index", "Profile") });
            }
        }

        public ActionResult OrderHistory()
        {
            if (Request.IsAuthenticated)
            {
                var userID = User.Identity.GetUserId();

                var order = db.Orders.Where(a => a.UserDataId == userID);



                //UserData userdata = Db.UserDatas.Find(userID);

                return View(order);


            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Index", "Profile") });
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult UserDetails()
        {
            if (Request.IsAuthenticated)
            {
                var userID = User.Identity.GetUserId();

                var user = db.UserDatas.Where(a => a.UserDataId == userID).SingleOrDefault();
                if (user != null)
                {
                    return View(user);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("UserDetails", "Profile") });
            }
        }

        [HttpPost]
        public ActionResult UserDetails(UserData userEditData)
        {
            if (ModelState.IsValid)
            {
                var userID = User.Identity.GetUserId();
                var user = db.UserDatas.Where(a => a.UserDataId == userID).SingleOrDefault();


                if (userEditData.UserDataId == null)
                {
                    var newUser = new UserData()
                    {
                        UserDataId = userID,
                        FirstName = userEditData.FirstName,
                        LastName = userEditData.LastName,
                        Address = userEditData.Address,
                        City = userEditData.City,
                        ZipCode = userEditData.ZipCode,
                        Email = userEditData.Email,
                        PhoneNumber = userEditData.PhoneNumber
                    };
                    db.UserDatas.Add(newUser);
                    db.SaveChanges();
                }
                else
                {
                    if (userEditData.UserDataId == userID)
                    {
                        user.UserDataId = userID;
                        user.FirstName = userEditData.FirstName;
                        user.LastName = userEditData.LastName;
                        user.Address = userEditData.Address;
                        user.City = userEditData.City;
                        user.ZipCode = userEditData.ZipCode;
                        user.Email = userEditData.Email;
                        user.PhoneNumber = userEditData.PhoneNumber;

                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }


                return RedirectToAction("Index");



            }

            return View(userEditData);
            
        }
        
    }
}