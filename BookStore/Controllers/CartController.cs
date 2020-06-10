using BookStore.Models;
using BookStore.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart

        private Model1 db = new Model1();
            public ActionResult Index()
            {
                var lstItemInCart = Session["CART_SESSION"] as List<CartItem>;
                return View(lstItemInCart);
            }

        [HttpPost]
        public JsonResult XoaSanPham(int productID)
        {
            try
            {
                var lstItemInCart = Session["CART_SESSION"] as List<CartItem>;
                var productRemoved = lstItemInCart.Single(item => item.Product.Masach == productID);
                lstItemInCart.Remove(productRemoved);
                Session["CART_SESSION"] = lstItemInCart;
                return Json(new { status = true });
            }
            catch (Exception ex)
            {
                return Json(new { status = false });
            }
        }
        [HttpPost]
        public JsonResult XoaNhieuSanPham(int[] listProduct)
        {
            try
            {
                var listItemInCart = Session["CART_SESSION"] as List<CartItem>;
                foreach (int productID in listProduct)
                {
                    var productRemoved = listItemInCart.Single(item => item.Product.Masach == productID);
                    listItemInCart.Remove(productRemoved);
                }
                Session["CART_SESSION"] = listItemInCart;
                return Json(new { status = true });
            }
            catch (Exception ex)
            {
                return Json(new { status = false });
            }
        }
        public ActionResult Checkout(string name, string phone, string email, string address)
        {


            try
            {
                var lstItemInCart = Session["CART_SESSION"] as List<CartItem>;
                var user = Session["USER_SESSION"] as Khachhang;
                decimal tongtien = 0;
              
                if (lstItemInCart != null)
                {
                    Giohangkh hoaDon = new Giohangkh();

                    hoaDon.Makh = user.Makh;
                    hoaDon.Ngaymua = DateTime.Now;
                    List<int> tempList = new List<int>();
                    foreach (var item in lstItemInCart)
                    {
                     
                        tongtien += item.Product.Dongia.Value * item.Quantity;
                        tempList.Add(item.Product.Masach);
                        ChiTietGioHang chiTiet = new ChiTietGioHang();
                        chiTiet.GiohangkhID = hoaDon.GiohangkhID;
                        chiTiet.Masach = item.Product.Masach;
                        chiTiet.Soluong = item.Quantity;
                        chiTiet.Thanhtien = item.Product.Dongia.Value * item.Quantity;
                        db.ChiTietGioHangs.Add(chiTiet);
                    }
                 
                    hoaDon.Tongtien = tongtien;
                    db.Giohangkhs.Add(hoaDon);
                    db.SaveChanges();

                    // remove session
                    int[] rmList = tempList.ToArray();
                    foreach (var item in rmList)
                    {
                        var productRemoved = lstItemInCart.Single(x => x.Product.Masach == item);
                        lstItemInCart.Remove(productRemoved);
                    }
                }
                Session["CART_SESSION"] = lstItemInCart;

                return Json(new { status = true });
            }
            catch (Exception ex)
            {
                return Json(new { status = false });
            }
        }
    }
}