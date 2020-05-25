using BookStore.Models;
using BookStore.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private Model1 db = new Model1();
      
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {

                Khachhang khachHang = db.Khachhangs.SingleOrDefault(item => item.Tendn == user.Username && item.Matkhau == user.Password);
                if (khachHang == null)
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng. Xin kiểm tra lại!");
                } else
                {
                    Session.Add("USER_SESSION", khachHang);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Login");
        }

        public JsonResult AddUser(Khachhang user)
        {
            try
            {
                Khachhang khachhang = db.Khachhangs.SingleOrDefault(i => i.Email == user.Email || i.Tendn==user.Tendn);
                if (khachhang != default) // ton tai email
                {
                    return Json(new
                    {
                        status = false,
                        message = khachhang.Tendn == user.Tendn
                                ? "TenDang Nhap da ton tai"
                                : "Email da duoc su dung"
                    }) ;
                }
                user.Quyen = 1;
                db.Khachhangs.Add(user);
                db.SaveChanges();
                if (Session["USER_SESSION"] == null)
                {
                    Session.Add("USER_SESSION", user);
                }
                else
                {
                    Session["USER_SESSION"] = user;
                }
                return Json(new { status = true });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "" });
            }

        }
        public ActionResult logout()
        {
            Session.Remove("USER_SESSION");
            return RedirectToAction("Index", "Home");
        }
    }
}