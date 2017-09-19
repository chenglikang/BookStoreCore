using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using BookStore.Tags;

namespace BookStore.Controllers
{
    //[Authorize]
    public class BookController : Controller
    {
        BookData _bookData = new BookData();

        public IActionResult Index(int? id, int page=1)
        {
            List<BookViewModel> list = _bookData.SelectBookByCategoryId(page,10,id);

            var catList = _bookData.SelectCategorys();

            ViewBag.CatList = catList;

            var pageOption = new MoPagerOption
            {
                CurrentPage = 1,
                PageSize = 2,
                Total = 20,
                RouteUrl = "/Book/Index/?id="
            };

            //分页参数
            ViewBag.PagerOption = pageOption;


            return View(list);
        }

        public IActionResult Details(int id)
        {
            BookDetailsViewModel book = _bookData.SelectBook(id);

            return View(book);
        }


    }
}