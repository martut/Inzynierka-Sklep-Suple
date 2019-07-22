using InzSklep.DAL;
using InzSklep.Infrastructure;
using InzSklep.Models;
using InzSklep.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InzSklep.Controllers
{
    public class CartController : Controller
    {
        private ShoppingCart shoppingCart;

        private ISession session { get; set; }

        private StoreContext db = new StoreContext();

        public CartController()
        {
            this.session = new SessionCart();
            this.shoppingCart = new ShoppingCart(this.session, this.db);
        }

        // GET: Cart
        public ActionResult Index()
        {
            var cartItem = shoppingCart.GetCart();
            var cartTotalPrice = shoppingCart.GetCartTotalPrice();

            CartViewModel cartVM = new CartViewModel()
            {
                CartItem = cartItem,
                TotalPrice = cartTotalPrice
            };

            return View(cartVM);
        }

        public ActionResult AddtoCart(int id)
        {
            shoppingCart.AddToCart(id);
            return RedirectToAction("Index");
        }

        public int GetCartItemCount()
        {
            return shoppingCart.GetCartItemCount();
        }

        public ActionResult RemoveFromCart(int id, int count, string backAction)
        {
            shoppingCart.RemoveFromCart(id, count);
            return RedirectToAction(backAction);
        }

        public ActionResult Checkout()
        {
            if (Request.IsAuthenticated)
            {
                var userID = User.Identity.GetUserId();

                var user = db.UserDatas.Where(a => a.UserDataId == userID).SingleOrDefault();
                if (user != null)
                {
                    var order = new Order()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Address = user.Address,
                        City = user.City,
                        ZipCode = user.ZipCode,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber
                    };
                    return View(order);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Checkout", "Cart") });
            }
        }

        [HttpPost]
        public ActionResult Checkout(Order orderdetails, bool updateCheckbox)
        {
            if (ModelState.IsValid)
            {
                var userID = User.Identity.GetUserId();

                var newOrder = shoppingCart.CreateOrder(orderdetails, userID);

                var user = db.UserDatas.Where(a => a.UserDataId == userID).SingleOrDefault();



                if (user != null)
                {
                    if (updateCheckbox)
                    {
                        shoppingCart.EmptyCart();

                        user.UserDataId = userID;
                        user.FirstName = orderdetails.FirstName;
                        user.LastName = orderdetails.LastName;
                        user.Address = orderdetails.Address;
                        user.City = orderdetails.City;
                        user.ZipCode = orderdetails.ZipCode;
                        user.Email = orderdetails.Email;
                        user.PhoneNumber = orderdetails.PhoneNumber;

                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    var newUser = new UserData()
                    {
                        UserDataId = userID,
                        FirstName = orderdetails.FirstName,
                        LastName = orderdetails.LastName,
                        Address = orderdetails.Address,
                        City = orderdetails.City,
                        ZipCode = orderdetails.ZipCode,
                        Email = orderdetails.Email,
                        PhoneNumber = orderdetails.PhoneNumber
                    };
                    db.UserDatas.Add(newUser);
                    db.SaveChanges();

                }

                return RedirectToAction("OrderConfirmation");


            }
            else
            {
                return View(orderdetails);
            }



        }

        public ActionResult OrderConfirmation()
        {
            return View();
        }

        
        public ActionResult NavbarMenu()
        {
            var cartItem = shoppingCart.GetCart();
            var cartTotalPrice = shoppingCart.GetCartTotalPrice();

            CartViewModel cartVM = new CartViewModel()
            {
                CartItem = cartItem,
                TotalPrice = cartTotalPrice
            };

            return PartialView("_NavbarCart", cartVM);
        }

    }
}