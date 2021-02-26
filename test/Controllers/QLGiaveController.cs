using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using test.Models.obj;

namespace test.Controllers
{
    public class QLGiaveController : Controller
    {
        // GET: QLGiave
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
               
                CtGiave ctgiave = new CtGiave();
                List<CtGiave> dsctgiave = ctgiave.GetChitietGiave();
                if (dsctgiave.Count > 0)
                {
                    ViewBag.danhsachgiave = dsctgiave;
                }
                tbl_Loaixe loaixe = new tbl_Loaixe();
                List<tbl_Loaixe> dsLoaixe = loaixe.GetLoaixeByPK(0);
                ViewBag.dsLoaixe = dsLoaixe;
                tbl_Loaive loaive = new tbl_Loaive();
                List<tbl_Loaive> dsLoaive = loaive.GetLoaiveByPK(0);
                ViewBag.dsLoaive = dsLoaive;
                tbl_Khunggio kg = new tbl_Khunggio();
                List<tbl_Khunggio> dsKhunggio = kg.GetKhunggioByPK(0);
                ViewBag.dsKhunggio = dsKhunggio;
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
        }
        public bool ThemGiave()
        {
            byte loaiveID = Convert.ToByte(Request["loaiveID"]);
            short loaixeID = Convert.ToInt16(Request["loaixeID"]);
            short khunggioID = Convert.ToInt16(Request["khunggioID"]);
            decimal giave = Convert.ToDecimal(Request["giave"]);
            DateTime ngaybatdauapdung = Convert.ToDateTime(Request["ngayapdung"]);
            tbl_Giave gv = new tbl_Giave();
            if (gv.ThemGiave(loaixeID, loaiveID, khunggioID, giave, ngaybatdauapdung))
                return true;
            else
                return false;

        }
    }
}