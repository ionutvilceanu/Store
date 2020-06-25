using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalaJocuriLicenta.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaJocuriLicenta.Models
{
    public class SCart
    {
        
            public string SCartId { get; set; }
            public List<SCartItem> SCartItems { get; set; }

            private readonly ApplicationDbContext _context;

            private SCart(ApplicationDbContext context)
            {
                _context = context;
            }

            public static SCart GetCart(IServiceProvider services)
            {
                ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                    .HttpContext.Session;

                var context = services.GetService<ApplicationDbContext>();
                string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

                session.SetString("CartId", cartId);

                return new SCart(context) { SCartId = cartId };
            }

            public void AddToCart(Product product, int amount)
            {
                var sCartItem = _context.SCartItems.SingleOrDefault(
                    s => s.Product.ProductId == product.ProductId && s.SCartId == SCartId);

                if (sCartItem == null)
                {
                    sCartItem = new SCartItem
                    {
                        SCartId = SCartId,
                        Product = product,
                        Amount = 1
                    };
                    _context.SCartItems.Add(sCartItem);

                }
                else
                {
                    sCartItem.Amount++;
                }

                _context.SaveChanges();
            }

            public int RemoveFromCart(Product product)
            {
                var sCartItem = _context.SCartItems.SingleOrDefault(
                    s => s.Product.ProductId == product.ProductId && s.SCartId == SCartId);

                var localAmount = 0;

                if (sCartItem != null)
                {
                    if (sCartItem.Amount > 1)
                    {
                        sCartItem.Amount--;
                        localAmount = sCartItem.Amount;
                    }
                    else
                    {
                        _context.SCartItems.Remove(sCartItem);
                    }
                }

                _context.SaveChanges();

                return localAmount;
            }

            public List<SCartItem> GetShoppingCartItems()
            {
                return SCartItems ??
                    (SCartItems = _context.SCartItems.Where(c => c.SCartId == SCartId)
                    .Include(s => s.Product)
                    .ToList());
            }

            public void ClearCart()
            {
                var cartItems = _context.SCartItems.Where(cart => cart.SCartId == SCartId);

                _context.SCartItems.RemoveRange(cartItems);

                _context.SaveChanges();
            }

            public float GetShoppingCartTotal()
            {
                var total = _context.SCartItems.Where(c => c.SCartId == SCartId)
                    .Select(c => c.Product.ProductPrice * c.Amount).Sum();

                return total;
            }
    }


    

}

