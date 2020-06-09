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
        public List<Sach> GetBookByChude(int? id)
        {
            return context.Saches.Where(i => i.Macd == id).ToList();
        }
        //public int CountBookByChuDe(int? id)
        //{
        //    List<Sach> items = context.Saches.ToList();
        //    //var count = items.Where(i => i.Macd == id).Count();
        //    var count = from s in items
        //                group s by s.Macd into sachbychude
        //                select new
        //                {
        //                    Macd = sachbychude.Key,
        //                    Count = sachbychude.Count(),
        //                };
        //    //var count = (from c in items group c by c.Macd).Count();
        //    return count;
        //}

        // GET: Books
        public ActionResult Index()
        {
            //ViewBag.ListAllBooks = GetAllBooks();
            //ViewBag.ListBookCate = GetChudes();
            //return View();


            var sach = context.Saches.ToList();
            return View(sach);


        }
        public ActionResult Details(int id)
        {

            var model = context.Saches.Find(id);
            ViewBag.productRelated = context.Saches.Where(i => i.Macd == model.Macd).ToList();
            ViewBag.productUpsell = context.Saches.Where(i => i.Giakm > model.Giakm).ToList();
            return View(model);
        }
        public ActionResult GetProductTag(int? id)
        {
            ViewBag.book = GetBookByChude(id);
            var chude = from cd in context.Chudes select cd;
            return PartialView(chude);
        }
        //public ActionResult BookByCategory(int id)
        //{
        //    var sach = context.Saches.Where(i => i.Macd == id).ToList();
        //    return View(sach);

        //}
        public ActionResult ProductCategory()
        {
            var items = context.Chudes.ToList();

            //var count = from s in items.GroupBy(s=>s.Macd)
            //            select new
            //            {
            //                Macd = s.Key,
            //                soluong1 = s.Count(),
            //            };
            var arr = new int[items.Count()];
            var j = 0;
            foreach (var it in items)
            {              
                arr[j]=context.Saches.Where(i => i.Macd == it.Macd).Count();
                j++;
            }
            ViewBag.countBook = arr;
            ViewBag.category = GetChudes();
            return PartialView();
        }

  

    }
}