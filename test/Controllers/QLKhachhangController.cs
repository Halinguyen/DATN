using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class QLKhachhangController : Controller
    {
        // GET: QLKhachhang
        public ActionResult Index()
        {
            tbl_Khachhang khachhang = new tbl_Khachhang();
            ViewBag.danhsachKhachhang = khachhang.GetKhachhangByPK(0);
            return View();
        }
    }
}