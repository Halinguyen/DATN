using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        //public JsonResult themmoi_hdnckh(int[] cb_thamgia)
        //{
        //    HD_NCKH hD_NCKH = new HD_NCKH();
        //    var chunhiem = Request["chunhiem"];
        //    var tenhd = Request["tenhd"];
        //    var thoigian = Request["thoigian"];
        //    var thoigian_kt = Request["thoigian_kt"];
        //    if (hD_NCKH.ThemSuKien(chunhiem.ToString(), tenhd.ToString(), thoigian.ToString(), cb_thamgia, thoigian_kt))
        //    {
        //        return Json(true);
        //    }
        //    else
        //    {
        //        return Json(false);
        //    }
        //}
        [HttpPost]
        public string Dangnhap()
        {
            tbl_Taikhoan tk = new tbl_Taikhoan();
            var tendangnhap = Request["tendangnhap"];
            var matkhau = Request["matkhau"];
            return (tk.GetTaikhoanDangnhap(tendangnhap,matkhau));
        }
    }
}