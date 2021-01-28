using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class DSNhanvienController : Controller
    {
        // GET: DSNhanvien
        public ActionResult Index()
        {
            tbl_Nhanvien nhanvien = new tbl_Nhanvien();
            ViewBag.danhsachNhanvien = nhanvien.GetNhanvienByPK(0);
            return View();
        }
        
    }
}