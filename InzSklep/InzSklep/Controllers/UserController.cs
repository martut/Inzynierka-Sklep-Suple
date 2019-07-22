using InzSklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InzSklep.ViewModel;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace InzSklep.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        // GET: User
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<UserViewModel> usersview = new List<UserViewModel>();
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            foreach (var item in db.Users)
            {
                usersview.Add(new UserViewModel
                {
                    user = item,
                    role = userManager.GetRoles(item.Id).FirstOrDefault()
                });
            }

            return View(usersview);
        }

        public ActionResult Permissions(string id)
        {
            var user = db.Users.Where(m => m.Id == id).FirstOrDefault();
            if (user == null)
                return HttpNotFound();

            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userview = new UserViewModel
            {
                user = user
            };
            ViewBag.Name = new SelectList(db.Roles.ToList(), "Name", "Name", userManager.GetRoles(user.Id).FirstOrDefault());


            return View(userview);
        }

        [HttpPost]
        public ActionResult Permissions(string id, string userRoles)
        {
            var user = db.Users.Where(m => m.Id == id).FirstOrDefault();
            if (user == null)
                return HttpNotFound();

            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            userManager.RemoveFromRoles(user.Id, userManager.GetRoles(user.Id).ToArray());
            userManager.AddToRole(user.Id, userRoles);
            userManager.UpdateSecurityStamp(user.Id);

            return RedirectToAction("Index");
        }
    }
}