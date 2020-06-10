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
        public ActionResult Index()
        {

            ViewBag.ListBookCate = context.Chudes.Where(i => i.Tenchude != null).ToList(); ;
            ViewBag.ListAllBooks = context.Saches.ToList(); ;

            ViewBag.ListBookBestSale = context.Saches.OrderByDescending(i => i.Giakm / i.Dongia).ToList();
            var newbooks = context.Saches.OrderByDescending(i => i.Ngaycapnhat).Take(5).ToList();           
            return View(newbooks);
        }
        
        
        
    }
}