using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using test.Models.obj;

namespace test.Controllers
{
    public class QLXeController : Controller
    {
        // GET: QLXe
        public ActionResult Index()
        {

            tbl_Xe xe = new tbl_Xe();
            List<tbl_Xe> dsXe = xe.GetXeByPK(0);
            Chitietxe ctxe = new Chitietxe();
            List<Chitietxe> dsctx = ctxe.XemChitietXe();
            ViewBag.danhsachxe = dsctx;
            return View();
        }
    }
}