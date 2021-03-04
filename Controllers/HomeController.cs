using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBooks.Models;
using OnlineBookStore.Models.ViewModels;

namespace OnlineBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookRespository _respository;

        public int PageSize = 5;
        //Controller
        public HomeController(ILogger<HomeController> logger, IBookRespository respository)
        {
            _logger = logger;
            _respository = respository;
        }
        //Passes our repository of Books.
        public IActionResult Index(string category, int page = 1)
        {
            return View(new BookListViewModel
            {
                Book = _respository.Books //Controls the dynamic output of our page based on the categories.
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.BookId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == null ? _respository.Books.Count() :
                    _respository.Books.Where (x => x.Category == category).Count()
                },
                CurrentCategory = category
            });
        }
        //Returns the privacy page.
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
