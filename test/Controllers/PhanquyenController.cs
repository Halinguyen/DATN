using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using test.Models.obj;

namespace test.Controllers
{
    public class PhanquyenController : Controller
    {
        // GET: Phanquyen
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
                ChitietQuyen ctq = new ChitietQuyen();
                List<ChitietQuyen> dsctq = ctq.XemChitietQuyen();
                tbl_Nhanvien nv = new tbl_Nhanvien();
                List<tbl_Nhanvien> dsnhanvien = nv.GetNhanvienByPK(0);
                tbl_Quyen quyen = new tbl_Quyen();
                List<tbl_Quyen> dsQuyen = quyen.GetQuyenByPK(0);
                 dsQuyen = dsQuyen.FindAll(q => q.PK_iQuyenID == 2);
                ViewBag.dsQuyen = dsQuyen;
                ViewBag.dsNhanvien = dsnhanvien;
                ViewBag.dsPhanquyen = dsctq; 
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
            
        }
        public string GetUsername()
        {
            string kq = "";
            long userID = Convert.ToInt64(Request["taikhoanID"]);
            if(userID > 0)
            {
                tbl_Taikhoan tk = new tbl_Taikhoan();
                List<tbl_Taikhoan> dstk = tk.GetTaikhoanByPK(userID);
                if(dstk.Count > 0)
                {
                    kq = dstk[0].sUsername;
                }
            }
            return kq;
        }

        public bool PhanquyenInsert()
        {          
            short quyenID = Convert.ToInt16(Request["quyenID"]);
            long taikhoanID = Convert.ToInt64(Request["taikhoanID"]);
            DateTime ngaybatdau = Convert.ToDateTime(Request["ngaybatdau"]);
            DateTime ngayketthuc = Convert.ToDateTime(Request["ngayketthuc"]);
            tbl_Phanquyen pq = new tbl_Phanquyen();
            if (pq.ThemPhanQuyen("", quyenID, ngaybatdau, ngayketthuc, taikhoanID))
                return true;
            else
                return false;          
        }
    }
}