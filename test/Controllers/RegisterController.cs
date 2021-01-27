using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Dangky()
        {
            tbl_Taikhoan tk = new tbl_Taikhoan();
            var tendangnhap = Request["tendangnhap"];
            var matkhau = Request["matkhau"];
            if (tk.ThemTaiKhoan(tendangnhap, matkhau))
                return Json(true);
            else
                return Json(false);
        }
    }
}