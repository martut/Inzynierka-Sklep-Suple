using InzSklep.DAL;
using InzSklep.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InzSklep.Infrastructure
{
    public class ShoppingCart
    {
        private StoreContext db;

        private ISession session;

        public const string CartSessionKey = "CartDate";



        public ShoppingCart(ISession session, StoreContext db)
        {
            this.session = session;
            this.db = db;
        }

        public List<CartItem> GetCart()
        {
            List<CartItem> cart;

            if (session.Get<List<CartItem>>(CartSessionKey) == null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = session.Get<List<CartItem>>(CartSessionKey) as List<CartItem>;
            }
            return cart;
        }

        public void AddToCart(int productid)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(a => a.Product.ProductId == productid);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                var productToAdd = db.Products.Where(a => a.ProductId == productid).SingleOrDefault();
                if (productToAdd != null)
                {
                    var newCartItem = new CartItem()
                    {
                        Product = productToAdd,
                        Quantity = 1,
                        TotalPrice = productToAdd.Price
                    };

                    cart.Add(newCartItem);
                }
            }

            session.Set(CartSessionKey, cart);
        }

        public void RemoveFromCart(int productid, int count)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(a => a.Product.ProductId == productid);
            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    if (cartItem.Quantity == count)
                    {
                        cart.Remove(cartItem);
                    }
                    else
                    {
                        cartItem.Quantity--;
                    }

                }
                else
                {
                    cart.Remove(cartItem);
                }
            }
            session.Set(CartSessionKey, cart);
        }

        public decimal GetCartTotalPrice()
        {
            var cart = this.GetCart();

            return cart.Sum(c => (c.Quantity * c.Product.Price));
        }

        public int GetCartItemCount()
        {
            var cart = this.GetCart();

            int count = cart.Sum(a => a.Quantity);

            return count;
        }

        public Order CreateOrder(Order newOrder, string userId)
        {
            var cart = this.GetCart();

            newOrder.CreateDate = DateTime.Now;
            newOrder.UserDataId = userId;

            this.db.Orders.Add(newOrder);

            if (newOrder.OrderItems == null)
            {
                newOrder.OrderItems = new List<OrderItem>();
            }

            decimal cartTotal = 0;

            foreach (var cartItem in cart)
            {
                var newOrderItem = new OrderItem()
                {
                    ProductId = cartItem.Product.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Product.Price
                };

                cartTotal += (cartItem.Quantity * cartItem.Product.Price);

                newOrder.OrderItems.Add(newOrderItem);
            }

            newOrder.TotalPrice = cartTotal;

            this.db.SaveChanges();

            newOrder.ForUserOrderId = String.Format("#{0}-{1}", newOrder.OrderId, newOrder.CreateDate.Date);
            db.Entry(newOrder).State = EntityState.Modified;
            this.db.SaveChanges();

            return newOrder;
        }

        public void EmptyCart()
        {
            session.Set<List<CartItem>>(CartSessionKey, null);
        }
    }
}