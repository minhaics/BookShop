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
        List<Sach> sach = new List<Sach>();
        private List<Chude> GetChudes()
        {
            return context.Chudes.Where(i => i.Tenchude != null).ToList();
        }
        private List<Sach> GetAllBooks()
        {
            return context.Saches.ToList();
        }
        // GET: Books
        public ActionResult Index(int id=1)
        {
            //ViewBag.ListAllBooks = GetAllBooks();
            //ViewBag.ListBookCate = GetChudes();
            //return View();
            
            if (id == 1)
            {
                sach = context.Saches.ToList();
            }
            else
            {
                sach = context.Saches.Where(i => i.Macd == id).ToList();
            }        
            return View(sach);


        }
        public ActionResult GetProductTag()
        {

            var chude = from cd in context.Chudes select cd;
            return PartialView(chude);
        }
        public ActionResult SanPhamTheoChuDe(int id)
        {
            var sach = context.Saches.Where(i => i.Macd == id);
            return View();

        }


  

    }
}