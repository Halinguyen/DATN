using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class DSKhudexeController : Controller
    {
        // GET: DSKhudexe
        public ActionResult Index()
        {
            tbl_Khudexe khudexe = new tbl_Khudexe();
            Database db = new Database();
            List <tbl_Khudexe> dsKhudexe = db.tbl_Khudexe.ToList();
            List<tbl_Loaixe> dsLoaixe = db.tbl_Loaixe.ToList();
            ViewBag.dskhudexe = dsKhudexe;
            ViewBag.dsloaixe = dsLoaixe;
            
            return View();
        }
        public JsonResult ThemKhudexe()
        {
            tbl_Khudexe kdx = new tbl_Khudexe();
            string tenKhudexe = Request["tenkhudexe"];
            short loaixeID = Convert.ToInt16(Request["loaixe"]);
            if (kdx.ThemKhudexe(tenKhudexe, loaixeID))
                return Json(true);
            else
                return Json(false);
        }
        public string GetKhudexe()
        {
            tbl_Khudexe kdx = new tbl_Khudexe();
            short khudexeID = Convert.ToInt16(Request["khudexeID"]);
            List<tbl_Khudexe> dsKhudexe = kdx.GetKhudexeByPK(khudexeID);
            return dsKhudexe[0].sTenkhu +"#" + dsKhudexe[0].FK_iLoaixeID;


        }
        public JsonResult SuaKhudexe()
        {
            string tenKhudexe = Request["tenkhudexe"];
            short loaixeID = Convert.ToInt16(Request["loaixe"]);
            short khudexeID = Convert.ToInt16(Request["makhudexe"]);
            tbl_Khudexe kdx = new tbl_Khudexe();
            if (kdx.SuaKhudexe(khudexeID, tenKhudexe, loaixeID))
                return Json(true);
            else
                return Json(false);
        }
        public JsonResult XoaKhudexe()
        {
            short khudexeID = Convert.ToInt16(Request["khudexeID"]);
            tbl_Khudexe kdx = new tbl_Khudexe();
            if (kdx.XoaKhudexe(khudexeID))
                return Json(true);
            else
                return Json(false);
        }
    }
}