using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using test.Models.obj;

namespace test.Controllers
{
    public class QLKhachhangController : Controller
    {
        // GET: QLKhachhang
        public ActionResult Index()
        {
            tbl_Khachhang khachhang = new tbl_Khachhang();
            tbl_Loaixe loaixe = new tbl_Loaixe();
            ViewBag.danhsachKhachhang = khachhang.GetKhachhangByPK(0);
            return View();
        }
        public JsonResult ThemKhachhang()
        {
            tbl_Khachhang kh = new tbl_Khachhang();
            var hoten = Request["hoten"];
            var sodienthoai = Request["sodienthoai"];
            var diachi = Request["diachi"];
            bool gioitinh = Convert.ToBoolean(Request["gioitinh"]);
            var tentaikhoan = Request["tentaikhoan"];
            var socmnd = Request["socmnd"];
            var masove = Request["masove"];
            long mataikhoan = 0;
            long mave = 2;

            tbl_Taikhoan tk = new tbl_Taikhoan();
            List<tbl_Taikhoan> danhsachtk = tk.getTaikhoanByTendangnhap(tentaikhoan);
            mataikhoan = danhsachtk[0].PK_iTaikhoanID;
            if(danhsachtk.Count < 0)
                return Json(false);
            tbl_Ve vexe = new tbl_Ve();
            List<tbl_Ve> dsvexe = vexe.GetVeBySoSeri(masove);
            mave = dsvexe[0].PK_iVeID;
            if (dsvexe.Count < 0)
                return Json(false);
            if (kh.ThemKhachhang(hoten,sodienthoai,diachi,gioitinh,mataikhoan,socmnd,mave))
                return Json(true);
            else
                return Json(false);
        }
        public JsonResult XoaKhachhang()
        {
            long khachhangID;
            tbl_Khachhang kh = new tbl_Khachhang();
            khachhangID = Convert.ToInt64(Request["makhachhang"]);
            if (kh.XoaKhachhang(khachhangID))
                return Json(true);
            else
                return Json(false);

        }
        public JsonResult SuaKhachhang()
        {
            var hoten = Request["hoten"];
            var sodienthoai = Request["sodienthoai"];
            var diachi = Request["diachi"];
            bool gioitinh = Convert.ToBoolean(Request["gioitinh"]);
            var tentaikhoan = Request["tentaikhoan"];
            var socmnd = Request["socmnd"];
            var masove = Request["masove"];
            long mataikhoan = 0;
            long mave = 0;
            tbl_Taikhoan tk = new tbl_Taikhoan();
            List<tbl_Taikhoan> danhsachtk = tk.getTaikhoanByTendangnhap(tentaikhoan);
            mataikhoan = danhsachtk[0].PK_iTaikhoanID;
            if (danhsachtk.Count < 0)
                return Json(false);
            tbl_Ve vexe = new tbl_Ve();
            List<tbl_Ve> dsvexe = vexe.GetVeBySoSeri(masove);
            mave = dsvexe[0].PK_iVeID;
            long khachhangID = Convert.ToInt64(Request["makhachhang"]);
            tbl_Khachhang kh = new tbl_Khachhang();
            if (kh.SuaKhachhang(khachhangID, hoten, sodienthoai, diachi, gioitinh, mataikhoan, socmnd, mave))
                return Json(true);
            else
                return Json(false);


        }
        public string GetKhachhang()
        {
            long khachhangID = Convert.ToInt64(Request["makhachhang"]);
            tbl_Khachhang kh = new tbl_Khachhang();
            List<khachhangobj> dsKhachhang = kh.GetKhachhangByPK(khachhangID);
            string ketqua = dsKhachhang[0].sHoten + "#" + dsKhachhang[0].sSodienthoai + "#" + dsKhachhang[0].sDiachi + "#" +
                dsKhachhang[0].bGioitinh + "#" + dsKhachhang[0].Username + "#" + dsKhachhang[0].sSoCMND + "#" + dsKhachhang[0].Soseri;
            return ketqua;

        }
    }
}