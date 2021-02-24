using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class QLLoaixeController : Controller
    {
        // GET: QLLoaixe
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
                tbl_Loaixe loaixe = new tbl_Loaixe();
                List<tbl_Loaixe> dsLoaixe = loaixe.GetLoaixeByPK(0);
                ViewBag.danhsachLoaixe = dsLoaixe;
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
            
        }
        public JsonResult ThemLoaixe()
        {
            string tenLoaixe = Request["tenloaixe"];
            tbl_Loaixe lx = new tbl_Loaixe();
            if (lx.ThemLoaixe(tenLoaixe))
                return Json(true);
            else
                return Json(false);
        }

        public JsonResult SuaLoaixe()
        {
            string tenLoaixe = Request["tenloaixe"];
            short loaixeID = Convert.ToInt16(Request["loaixeID"]);
            tbl_Loaixe lx = new tbl_Loaixe();
            if (lx.SuaLoaixe(loaixeID,tenLoaixe))
                return Json(true);
            else
                return Json(false);
        }
        public JsonResult XoaLoaixe()
        {
            short loaixeID = Convert.ToInt16(Request["loaixeID"]);
            tbl_Loaixe lx = new tbl_Loaixe();
            if (lx.XoaLoaixe(loaixeID))
                return Json(true);
            else
                return Json(false);
        }

        public string GetLoaixe()
        {
            short loaixeID = Convert.ToInt16(Request["loaixeID"]);
            tbl_Loaixe lx = new tbl_Loaixe();
            List<tbl_Loaixe> dsLoaixe = lx.GetLoaixeByPK(loaixeID);
            return dsLoaixe[0].sTenLoaixe;
        }
    }
}