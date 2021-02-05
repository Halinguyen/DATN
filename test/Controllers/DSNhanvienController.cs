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
        public JsonResult ThemNhanvien()
        {
            tbl_Nhanvien nhanvien = new tbl_Nhanvien();
            var hoten = Request["hoten"];
            var sodienthoai = Request["sodienthoai"];
            var diachi = Request["diachi"];
            bool gioitinh = Convert.ToBoolean(Request["gioitinh"]);
            var tentaikhoan = Request["tentaikhoan"];
            var socmnd = Request["socmnd"];
            var ngaysinh = Request["ngaysinh"];
            var ngayvaolam = Request["ngayvaolam"];
            var trangthailamviec = Request["trangthailamviec"];
            long mataikhoan = 0;
            tbl_Taikhoan tk = new tbl_Taikhoan();
            List<tbl_Taikhoan> danhsachtk = tk.getTaikhoanByTendangnhap(tentaikhoan);
            mataikhoan = danhsachtk[0].PK_iTaikhoanID;
            if (danhsachtk.Count < 0)
                return Json(false);
            if (nhanvien.ThemNhanvien(hoten, Convert.ToDateTime(ngaysinh), diachi, Convert.ToBoolean(gioitinh), sodienthoai, socmnd,
                Convert.ToDateTime(ngayvaolam), mataikhoan, Convert.ToByte(trangthailamviec)))
                return Json(true);
            else
                return Json(false);


        }

        public string GetNhanvien()
        {
            short nhanvienID = Convert.ToInt16(Request["nhanvienID"]);
            tbl_Nhanvien nv = new tbl_Nhanvien();
            List<tbl_Nhanvien> danhsachnhanvien = new List<tbl_Nhanvien>();
            danhsachnhanvien = nv.GetNhanvienByPK(nhanvienID);
            tbl_Taikhoan tk = new tbl_Taikhoan();
            List<tbl_Taikhoan> danhsachTaikhoan = new List<tbl_Taikhoan>();
            danhsachTaikhoan = tk.GetTaikhoanByPK(danhsachnhanvien[0].FK_iTaikhoanID);
            return danhsachnhanvien[0].sHoten + "#" + danhsachnhanvien[0].dNgaysinh.ToString("yyyy-MM-dd") + "#" + danhsachnhanvien[0].sDiachi + "#" + danhsachnhanvien[0].bGioitinh + "#" + danhsachnhanvien[0].sSodienthoai + "#" + danhsachnhanvien[0].sSoCMND + "#" + danhsachnhanvien[0].dNgayvaolam.ToString("yyyy-MM-dd") + "#" + danhsachTaikhoan[0].sUsername + "#" + danhsachnhanvien[0].bTrangthailamviec;

        }

        public JsonResult SuaNhanvien()
        {
            tbl_Nhanvien nhanvien = new tbl_Nhanvien();
            var hoten = Request["hoten"];
            var sodienthoai = Request["sodienthoai"];
            var diachi = Request["diachi"];
            bool gioitinh = Convert.ToBoolean(Request["gioitinh"]);
            var tentaikhoan = Request["tentaikhoan"];
            var socmnd = Request["socmnd"];
            var ngaysinh = Request["ngaysinh"];
            var ngayvaolam = Request["ngayvaolam"];
            var trangthailamviec = Request["trangthailamviec"];
            long mataikhoan = 0;
            short nhanvienID = Convert.ToInt16(Request["manhanvien"]);
            tbl_Taikhoan tk = new tbl_Taikhoan();
            List<tbl_Taikhoan> danhsachtk = tk.getTaikhoanByTendangnhap(tentaikhoan);
            mataikhoan = danhsachtk[0].PK_iTaikhoanID;
            if (danhsachtk.Count < 0)
                return Json(false);
            if (nhanvien.SuaNhanvien(nhanvienID,hoten, Convert.ToDateTime(ngaysinh), diachi, Convert.ToBoolean(gioitinh), sodienthoai, socmnd,
                Convert.ToDateTime(ngayvaolam), mataikhoan, Convert.ToByte(trangthailamviec)))
                return Json(true);
            else
                return Json(false);

        }


    }
}