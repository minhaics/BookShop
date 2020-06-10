using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private Model1 context = new Model1();
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
    

        // GET: Books
        public ActionResult Index(int? id, int? page)
        {
            if (id == null)
            {
                var sach = context.Saches.OrderByDescending(x => x.Dongia).ToPagedList(page ?? 1, 4);
                
                return View(sach);
            }
            else
            {
                var sach = context.Saches.Where(i => i.Macd == id).OrderByDescending(x => x.Dongia).ToPagedList(page ?? 1, 4);

                return View(sach);
            }



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
        public ActionResult BookByCategory(int id)
        {
            var sach = context.Saches.Where(i => i.Macd == id).ToList();
            return View(sach);

        }
        public ActionResult ProductCategory()
        {
            var items = context.Chudes.ToList();
            var arr = new int[items.Count()];
            var j = 0;
            foreach (var it in items)
            {
                arr[j] = context.Saches.Where(i => i.Macd == it.Macd).Count();
                j++;
            }
            ViewBag.countBook = arr;
            ViewBag.category = GetChudes();
            return PartialView();
        }

        public ActionResult Search(string search)
        {
            var model = context.Saches.Where(i => i.Tensach.Equals(search)).ToList();
            return View("Index", model);
        }

    }
}