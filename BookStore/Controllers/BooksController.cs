using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BookStore.Models;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private Model1 context= new Model1();
        private List<Chude> GetChudes()
        {
            return context.Chudes.Where(i => i.Tenchude != null).ToList();
        }
        private List<Sach> GetAllBooks()
        {
            return context.Saches.ToList();
        }
        // GET: Books
        public ActionResult Index()
        {
            ViewBag.ListAllBooks = GetAllBooks();
            ViewBag.ListBookCate = GetChudes();
            return View();

        }

    }
}