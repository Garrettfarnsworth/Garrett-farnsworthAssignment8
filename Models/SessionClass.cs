using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json.Serialization;
using OnlineBookStore.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookStore.Infastructure;
using OnlineBooks.Models;

namespace OnlineBookStore.Models
{
    public class SessionClass : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            Cart cart = session?.GetJson<Cart>("Cart")
                ?? new Cart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Books books, int quantity)
        {
            base.AddItem(books, quantity);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Books books)
        {
            base.RemoveLine(books);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
