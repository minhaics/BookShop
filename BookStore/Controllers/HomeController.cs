using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BookStore.Models;
namespace BookStore.Controllers

{
    public class HomeController : Controller
    {
        private Model1 context = new Model1();
        private List<Sach> GetNewBooks(int count)
        {
            return context.Saches.OrderByDescending(i => i.Ngaycapnhat).Take(count).ToList();
        }
        private List<Chude> GetChudes()
        {
            return context.Chudes.Where(i => i.Tenchude != null).ToList();
        }

        private List<Sach> GetAllBooks()
        {
            return context.Saches.ToList();
        }
        public ActionResult Index()
        {

            ViewBag.ListBookCate = GetChudes();
            ViewBag.ListAllBooks = GetAllBooks();
            var newbooks = GetNewBooks(5);
                return View(newbooks);
        }

        
        
    }
}