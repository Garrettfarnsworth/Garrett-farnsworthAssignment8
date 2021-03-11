using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBooks.Models;
using OnlineBookStore.Infastructure;
using OnlineBookStore.Models;

namespace OnlineBookStore.Pages
{
    public class DonateModel : PageModel
    {
        private IBookRespository repository;

        //Constructor
        public DonateModel(IBookRespository repo)
        {
            repository = repo;
        }

        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //Methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        //Parameters for the URL and this will return the new Url based on what has been passed in.
        //the BookId has to match in both line 36 and 40 as well as in the project summary asp-for="". 
        public IActionResult OnPost(long BookId, string returnUrl)
        {
            Books books = repository.Books.FirstOrDefault(p => p.BookId == BookId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(books, 1);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
        //Removing the added book.
        public IActionResult OnPostRemove(long BookId, string returnUrl)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.RemoveLine(Cart.Lines.FirstOrDefault(cl =>
                cl.Books.BookId == BookId).Books);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}