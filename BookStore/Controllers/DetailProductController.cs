using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class DetailProductController : Controller
    {
        // GET: DetailProduct

        private Model1 context = new Model1();

        public ActionResult Index(int id= 1008)
        {
            var sach = context.Saches.Where(i => i.Masach == id).FirstOrDefault();
            return View(sach);
        }




    }
}