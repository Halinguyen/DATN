using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class QLVexeController : Controller
    {
        // GET: QLVexe
        public ActionResult Index()
        {       
            if (Session["IsLogin"].Equals(true))
            {
                tbl_Ve vexe = new tbl_Ve();
                List<tbl_Ve> dsVexe = vexe.GetVexeByPK(0);
                ViewBag.dsVexe = dsVexe;
                return View();
            }
            else
                return RedirectToAction("Index", "Login");

        }
        public bool ThemttVe()
        {
            string maVexe = Request["mavexe"];
            DateTime ngayhethan = Convert.ToDateTime(Request["ngayhethan"]);
            tbl_Ve vexe = new tbl_Ve();
            bool kq = false;
            if (vexe.InsertVexe(maVexe, ngayhethan))
                kq = true;
            else
                kq = false;
            return kq;
        }

        public bool SuattVe()
        {
            tbl_Ve vexe = new tbl_Ve();
            bool kq = false;
            string maVexe = Request["mavexe"];
            DateTime ngayhethan = Convert.ToDateTime(Request["ngayhethan"]);
            long vexeID = Convert.ToInt64(Request["vexeID"]);
            DateTime ngaytao = Convert.ToDateTime(Request["ngayhethan"]);
            if (vexe.UpdateVexe(vexeID, maVexe, ngaytao, ngayhethan))
                kq = true;
            else
                kq = false;

            return kq;


        }
        public string XemttVe()
        {
            string kq = "";
            tbl_Ve vexe = new tbl_Ve();
            List<tbl_Ve> dsvexe = new List<tbl_Ve>();
            long vexeID = Convert.ToInt64(Request["mave"]);
            if(vexeID > 0)
            {
                dsvexe = vexe.GetVexeByPK(vexeID);
                if(dsvexe.Count > 0)
                {
                    kq = dsvexe[0].PK_iVeID + "#" + dsvexe[0].sMave + "#" + dsvexe[0].tNgaytao.ToString("yyyy-MM-dd") + "#" + dsvexe[0].tNgayhethan.ToString("yyyy-MM-dd") + "#" + dsvexe[0].bTrangthai;
                }
            }
            return kq;
        }

        public bool ChuyentrangthaiVe()
        {
            bool kq = false;
            tbl_Ve vexe = new tbl_Ve();
            long vexeID = Convert.ToInt64(Request["mave"]);
            bool trangthai = Convert.ToBoolean(Request["trangthai"]);
            if(vexeID > 0)
            {
                if (vexe.ChuyentrangthaiVexe(vexeID, trangthai))
                    kq = true;
                else
                    kq = false;
            }
            return kq;
        }

        
    }
}