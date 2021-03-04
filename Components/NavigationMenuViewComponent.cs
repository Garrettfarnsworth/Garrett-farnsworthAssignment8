using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBooks.Models;

namespace OnlineBookStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookRespository repository;
        public NavigationMenuViewComponent (IBookRespository r)
        {
            repository = r;
        }
        public IViewComponentResult Invoke()
        { //This helps with highlighting the feidls as well as showing them. Builds the feilds dynamically based off the categories.
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
