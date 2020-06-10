using BookStore.Models;
using BookStore.Models.common;
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

        private Model1 db = new Model1();
       
        private const string CartSession = "CART_SESSION";

        public ActionResult Index(int id= 1008)
        {
            var sach = db.Saches.SingleOrDefault(item => item.Masach == id);
            if (sach == null)
            {
                Response.StatusCode = 404;
                Response.StatusDescription = "Không có sách này";
            }
            return View(sach);
        }

        public JsonResult AddToCart(int productID, int quantity)
        {
            var listProductInCart = Session[CartSession];
            var listItem = new List<CartItem>();

            if (listProductInCart == null)
            {
                var product = new CartItem();
                product.Product = db.Saches.SingleOrDefault(item => item.Masach == productID);
                product.Quantity = quantity;
                listItem.Add(product);
            }
            else
            {
                listItem = (List<CartItem>)listProductInCart;
                bool isExisting = listItem.Exists(item => item.Product.Masach == productID);
                if (isExisting)
                {
                    var product = listItem.SingleOrDefault(item => item.Product.Masach == productID);
                    product.Quantity += quantity;
                }
                else
                {
                    var product = new CartItem();
                    product.Product = db.Saches.SingleOrDefault(item => item.Masach == productID);
                    product.Quantity = quantity;
                    listItem.Add(product);
                }
            }
            Session[CartSession] = listItem;
            return Json(new { status = true });
        }

        public ActionResult TotalPrice()
        {
            var lstItemInCart = Session["CART_SESSION"] as List<CartItem>;
            decimal tongtien = 0;
            if (lstItemInCart != null)
            {
                foreach (var item in lstItemInCart)
                {
                    tongtien += (decimal)item.Product.Dongia * item.Quantity;
                }
            }
            return Json(tongtien, JsonRequestBehavior.AllowGet);
        }


    }
}