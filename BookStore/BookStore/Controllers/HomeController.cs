using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Data;
using Microsoft.AspNetCore.Http;
namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            BookData bookData = new BookData();
            //HttpContext.Session.SetString("user", "name");

            List<BookViewModel> list = bookData.SelectNewBook(20);
            
            return View(list);
        }

        public IActionResult About()
        {
            //if (HttpContext.Session.GetString("user") != null)
            {

            }
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
